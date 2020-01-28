param(
  [string]$resourceGroup = "test-sb-logic-app-sample-rg",
  [string]$templateFile = ".\azuredeploy.json",
  [string]$templateParameterFile = "azuredeploy.parameters.json",
  [string]$functionAppName = "",
  [string]$dataLakeAccountKey = "",
  [string]$sbConnectionString = ""
)

#update settings
$sbConnectionStringSecure = ConvertTo-SecureString $sbConnectionString -AsPlainText -Force
$dataLakeAccountKeySecure = ConvertTo-SecureString $dataLakeAccountKey -AsPlainText -Force

New-AzResourceGroupDeployment `
-ResourceGroupName $resourceGroup `
-TemplateFile $templateFile `
-TemplateParameterFile $templateParameterFile `
-azureWebJobsServiceBus $sbConnectionStringSecure `
-dataLakeAccountKey $dataLakeAccountKeySecure 

#publish function app code
# requires .NET Core and the function core tools installed locally
cd ..\..\..\functionApp\
func azure functionapp publish $functionAppName --force

