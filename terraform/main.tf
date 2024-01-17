provider "azurerm" {
  features {}
  use_oidc = true
  skip_provider_registration = "true"
}

resource "azurerm_resource_group" "resource_group_homecook" {
  name     = local.home_cook_rg_name
  location = var.location
}

resource "azurerm_storage_account" "storage_account_homecook_files_api" {
  name                     = local.storage_account_homecook_files_api_name
  resource_group_name      = azurerm_resource_group.resource_group_homecook.name
  location                 = azurerm_resource_group.resource_group_homecook.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_service_plan" "service_plan_homecook" {
  name                = local.service_plan_homecook_name
  resource_group_name = azurerm_resource_group.resource_group_homecook.name
  location            = azurerm_resource_group.resource_group_homecook.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "web_app_homecook_main" {
  name                = local.web_app_homecook_main_name
  resource_group_name = azurerm_resource_group.resource_group_homecook.name
  location            = azurerm_service_plan.service_plan_homecook.location
  service_plan_id     = azurerm_service_plan.service_plan_homecook.id
  enabled = false

  site_config {}
}