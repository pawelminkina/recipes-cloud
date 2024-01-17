variable "location" {}
variable "environment" {
      default = "dev"
}

locals {
    
    homecook_project_name = "homecook"
    short_location = var.location == "North Europe" ? "ne" : "we"

    home_cook_rg_name                       = "${var.environment}-${local.short_location}-${local.homecook_project_name}-rg"
    storage_account_homecook_files_api_name = "${var.environment}${local.short_location}${local.homecook_project_name}sa"

    service_plan_af_consumption_homecook_name              = "${var.environment}-${local.short_location}-${local.homecook_project_name}-sp"
    service_plan_homecook_name              = "${var.environment}-${local.short_location}-${local.homecook_project_name}-sp"
    web_app_homecook_main_name              = "${var.environment}-${local.short_location}-${local.homecook_project_name}-wa"
}


#List of short names:
#rg - resource group
#sa - storage account
#sp - service plan
#wa - web app
#af - azure function
#sqls - sql server
#sqldb - sql server database