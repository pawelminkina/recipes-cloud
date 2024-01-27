provider "azurerm" {
  features {}
  use_oidc = true
  skip_provider_registration = "true"
}

resource "azurerm_resource_group" "resource_group_homecook" {
  name     = local.home_cook_rg_name
  location = var.location
}

#storage accounts

resource "azurerm_storage_account" "storage_account_homecook_files_api" {
  name                     = local.storage_account_homecook_files_api_name
  resource_group_name      = azurerm_resource_group.resource_group_homecook.name
  location                 = azurerm_resource_group.resource_group_homecook.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_account" "storage_account_homecook_af_storage" {
  name                     = local.storage_account_homecook_af_storage_name
  resource_group_name      = azurerm_resource_group.resource_group_homecook.name
  location                 = azurerm_resource_group.resource_group_homecook.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "container_files_api" {
  name                  = local.sa_container_homecook_files_api_name
  storage_account_name  = azurerm_storage_account.storage_account_homecook_files_api.name
  container_access_type = "private"
}


#service plans

resource "azurerm_service_plan" "service_plan_homecook" {
  name                = local.service_plan_homecook_name
  resource_group_name = azurerm_resource_group.resource_group_homecook.name
  location            = azurerm_resource_group.resource_group_homecook.location
  os_type             = "Windows"
  sku_name            = "F1"
}

resource "azurerm_service_plan" "service_plan_homecook_azure_functions" {
  name                = local.service_plan_af_consumption_homecook_name
  resource_group_name = azurerm_resource_group.resource_group_homecook.name
  location            = azurerm_resource_group.resource_group_homecook.location
  os_type             = "Windows"
  sku_name            = "Y1"
}

# app insight 
resource "azurerm_application_insights" "webapp_app_insight" {
  name                = local.ui_app_insight_name
  resource_group_name = azurerm_resource_group.resource_group_homecook.name
  location            = azurerm_resource_group.resource_group_homecook.location
  application_type    = "web"
}

#web apps

resource "azurerm_windows_web_app" "web_app_homecook_main" {
  name                = local.web_app_homecook_main_name
  resource_group_name = azurerm_resource_group.resource_group_homecook.name
  location            = azurerm_service_plan.service_plan_homecook.location
  service_plan_id     = azurerm_service_plan.service_plan_homecook.id
  enabled = true
  public_network_access_enabled = true
  site_config {
    always_on = false
  }

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" =  azurerm_application_insights.webapp_app_insight.instrumentation_key
    "APPLICATIONINSIGHTS_CONNECTION_STRING" =  azurerm_application_insights.webapp_app_insight.connection_string
    "ApplicationInsightsAgent_EXTENSION_VERSION" = "~3"
    "DeployedEnvironment"= "Azure"
    "WEBSITE_RUN_FROM_PACKAGE" = 1
    "AzureStorageAccount__ConnectionString" = azurerm_storage_account.storage_account_homecook_files_api.primary_connection_string
    "AzureStorageAccount__PhotosContainerName" = local.sa_container_homecook_files_api_name
    "ServicesConfig__FileServiceBaseUrl" = "https://${azurerm_windows_function_app.function_app_files.default_hostname}"
    "ServicesConfig__RecipeServiceBaseUrl" = "https://${azurerm_windows_function_app.function_app_recipes.default_hostname}"
  }
    depends_on = [azurerm_windows_function_app.function_app_recipes, azurerm_windows_function_app.function_app_files, azurerm_application_insights.webapp_app_insight]
}

#azure functions
resource "azurerm_windows_function_app" "function_app_recipes" {
  name                = local.function_app_recipes_name
  resource_group_name = azurerm_resource_group.resource_group_homecook.name
  location            = azurerm_resource_group.resource_group_homecook.location
  public_network_access_enabled = true
  enabled = true
  storage_account_name       = azurerm_storage_account.storage_account_homecook_af_storage.name
  storage_account_access_key = azurerm_storage_account.storage_account_homecook_af_storage.primary_access_key
  service_plan_id            = azurerm_service_plan.service_plan_homecook_azure_functions.id
  
  site_config {
    application_stack {
      dotnet_version = "v7.0"
      use_dotnet_isolated_runtime = true
    }
  }

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" =  azurerm_application_insights.webapp_app_insight.instrumentation_key
    "APPLICATIONINSIGHTS_CONNECTION_STRING" =  azurerm_application_insights.webapp_app_insight.connection_string
    "ApplicationInsightsAgent_EXTENSION_VERSION" = "~3"
    "WEBSITE_RUN_FROM_PACKAGE" = 1
    "FUNCTIONS_EXTENSION_VERSION"         = "~4"
    "FUNCTIONS_WORKER_RUNTIME"            = "dotnet-isolated"
    "SCM_DO_BUILD_DURING_DEPLOYMENT" = true
    "RecipeDatabaseConnectionString" = "Server=tcp:${azurerm_mssql_server.sql_server_homecook.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_mssql_database.sql_database_recipes.name};Persist Security Info=False;User ID=${azurerm_mssql_server.sql_server_homecook.administrator_login};Password=${azurerm_mssql_server.sql_server_homecook.administrator_login_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=120;"
  }

  depends_on = [azurerm_mssql_server.sql_server_homecook]
}

resource "azurerm_windows_function_app" "function_app_files" {
  name                = local.function_app_files_name
  resource_group_name = azurerm_resource_group.resource_group_homecook.name
  location            = azurerm_resource_group.resource_group_homecook.location
  public_network_access_enabled = true
  enabled = true
  
  storage_account_name       = azurerm_storage_account.storage_account_homecook_af_storage.name
  storage_account_access_key = azurerm_storage_account.storage_account_homecook_af_storage.primary_access_key
  service_plan_id            = azurerm_service_plan.service_plan_homecook_azure_functions.id

  site_config {
    application_stack {
      dotnet_version = "v7.0"
      use_dotnet_isolated_runtime = true
    }
  }

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" =  azurerm_application_insights.webapp_app_insight.instrumentation_key
    "APPLICATIONINSIGHTS_CONNECTION_STRING" =  azurerm_application_insights.webapp_app_insight.connection_string
    "ApplicationInsightsAgent_EXTENSION_VERSION" = "~3"
    "FUNCTIONS_EXTENSION_VERSION"         = "~4"
    "FUNCTIONS_WORKER_RUNTIME"            = "dotnet-isolated"
    "SCM_DO_BUILD_DURING_DEPLOYMENT" = true
    "WEBSITE_RUN_FROM_PACKAGE" = 1
    "FilesDatabaseConnectionString" = "Server=tcp:${azurerm_mssql_server.sql_server_homecook.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_mssql_database.sql_database_files.name};Persist Security Info=False;User ID=${azurerm_mssql_server.sql_server_homecook.administrator_login};Password=${azurerm_mssql_server.sql_server_homecook.administrator_login_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=120;"
  }
}

# #sql server
resource "azurerm_mssql_server" "sql_server_homecook" {
  name                         = local.sql_server_homecook_name
  resource_group_name          = azurerm_resource_group.resource_group_homecook.name
  location                     = azurerm_resource_group.resource_group_homecook.location
  version                      = "12.0"
  administrator_login          = "4dm1n157r470r" #that set from pipeline
  administrator_login_password = var.SQL_DATABASE_PASSWORD
}


# #sql databases
resource "azurerm_mssql_database" "sql_database_recipes" {
  name           = local.sql_database_homecook_recipes_name
  server_id      = azurerm_mssql_server.sql_server_homecook.id
  sku_name       = "Basic"
}

resource "azurerm_mssql_database" "sql_database_files" {
  name           = local.sql_database_homecook_files_name
  server_id      = azurerm_mssql_server.sql_server_homecook.id
  sku_name       = "Basic"
}

resource "azurerm_mssql_firewall_rule" "internal_azure_connection_homecook" {
  name             = "FirewallRule1"
  server_id        = azurerm_mssql_server.sql_server_homecook.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}