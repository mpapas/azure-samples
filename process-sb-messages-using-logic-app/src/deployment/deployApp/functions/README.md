# Deploy Function App

Once you've successfully provisioned your Azure resources, you can deploy and configure the Function App code. You will need the Azure Functions Core Tools and the dotnet SDK (3.1.101).

Refer to the generated Azure resources for the following arguments.

**.\deploy.ps1 \`  
  -resourceGroup \<name of the resource group\> \`  
  -functionAppName \<name of the Function App\> \`  
  -dataLakeAccountKey \<account key from the gen2 storage account\> \`  
  -sbConnectionString \<service bus connection string\>**
  
  
