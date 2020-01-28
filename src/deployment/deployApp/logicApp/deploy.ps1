param(
  [string]$resourceGroupName = "test-sb-logic-app-sample-rg",
  [string]$templateFile = ".\azuredeploy.json",
  [string]$templateParameterFile = "azuredeploy.parameters.json",
  [string]$sbConnectionString = ""
)

$sbConnectionStringSecure = ConvertTo-SecureString $sbConnectionString `
-AsPlainText `
-Force

New-AzResourceGroupDeployment `
-ResourceGroupName $resourceGroupName `
-TemplateFile $templateFile `
-TemplateParameterFile $templateParameterFile `
-servicebus_1_connectionString $sbConnectionStringSecure
