variable "location" {}
variable "environment" {
      default = "dev"
}

locals {
    homecook_project_name = "homecook"
    short_location = var.location == "North Europe" ? "ne" : "we"

    home_cook_rg_name = "${var.environment}-${short_location}-${homecook_project_name}-rg"
    storage_account_homecook_files_api_name = "${var.environment}-${short_location}-${homecook_project_name}-sa"

}