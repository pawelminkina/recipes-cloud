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
  name                     = "storageaccountname"
  resource_group_name      = azurerm_resource_group.resource_group_homecook.name
  location                 = azurerm_resource_group.resource_group_homecook.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}