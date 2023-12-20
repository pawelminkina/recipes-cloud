terraform {
  cloud {
    organization = "pawel-minkina-thesis"

    workspaces {
      name = "recipe-thesis"
    }
  }

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.7.0"
    }
  }
}