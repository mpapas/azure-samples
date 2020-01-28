param(
  [string]$resourceGroupName = "test-sb-logic-app-sample-rg",
  [string]$resourceGroupLocation = "centralus", 
  [string]$templateFile = ".\azuredeploy.json",
  [string]$templateParameterFile = "azuredeploy.parameters.json"
)

<#
$resourceGroupName
$resourceGroupLocation
$templateFile
$templateParameterFile
#>

# Create a resource group
New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation

# Deploy Resources
New-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName `
  -TemplateFile $templateFile `
  -TemplateParameterFile $templateParameterFile
