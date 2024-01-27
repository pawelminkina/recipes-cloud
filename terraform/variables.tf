variable "location" {
    default = "northeurope"
}
variable "environment" {
      default = "dev"
}
variable "sql_database_pwd" {
      default = ""
      sensitive = true
}
#$
locals {
    
    homecook_project_name = "homecook"
    short_location = var.location == "northeurope" ? "ne" : "we"

    home_cook_rg_name                           = "${var.environment}-${local.short_location}-${local.homecook_project_name}-rg"
    home_cook_rg_azurefunctions_name            = "${var.environment}-${local.short_location}-${local.homecook_project_name}-functions-rg"
    storage_account_homecook_files_api_name     = "${var.environment}${local.short_location}${local.homecook_project_name}sa"
    storage_account_homecook_af_storage_name    = "${var.environment}${local.short_location}${local.homecook_project_name}afsa"
    sa_container_homecook_files_api_name        = "homecook-files"



    service_plan_af_consumption_homecook_name   = "${var.environment}-${local.short_location}-${local.homecook_project_name}-cons-sp"
    service_plan_homecook_name                  = "${var.environment}-${local.short_location}-${local.homecook_project_name}-sp"
    web_app_homecook_main_name                  = "${var.environment}-${local.short_location}-${local.homecook_project_name}-wa"
    function_app_recipes_name                   = "${var.environment}-${local.short_location}-${local.homecook_project_name}-recipes-fa"
    function_app_files_name                     = "${var.environment}-${local.short_location}-${local.homecook_project_name}-files-fa"

    ui_app_insight_name   = "${var.environment}-${local.short_location}-${local.homecook_project_name}-ui-ai"

    sql_server_homecook_name                    = "${var.environment}-${local.short_location}-${local.homecook_project_name}-sqls"
    sql_database_homecook_files_name            = "${var.environment}-${local.short_location}-${local.homecook_project_name}-files-sqldb"
    sql_database_homecook_recipes_name          = "${var.environment}-${local.short_location}-${local.homecook_project_name}-recipes-sqldb"
}


#List of short names:
#rg - resource group
#sa - storage account
#sp - service plan
#wa - web app
#af - azure function
#sqls - sql server
#sqldb - sql server database