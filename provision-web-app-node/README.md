# Azure App service web app regional vNet integration, SQL DB and Azure Storage account Private endpoint scenario 

[![Deploy To Azure](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmpapas%2Fazure-samples%2Fmaster%2Fprovision-web-app-python-postgreSQL%2Fazuredeploy.json)
[![Visualize](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/visualizebutton.svg?sanitize=true)](http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Fmpapas%2Fazure-samples%2Fmaster%2Fprovision-web-app-python-postgreSQL%2Fazuredeploy.json)

### Overview

This solution deploys an Azure App Services web app configured for Nodejs. The web app has its own private link and private DNS resources to only allow access to these resources over a private address space.

The following resources are deployed as part of this solution:

- TBD

  Note that for traffic to pass from the web app to the private endpoints, the following web app environment variables must be set in the app.json nested template.

  "siteConfig": {
                    "appSettings": [
                        {
                            "name": "WEBSITE_VNET_ROUTE_ALL",
                            "value": 1
                        },
                        {
                            "name": "WEBSITE_DNS_SERVER",
                            "value": "168.63.129.16"
                        }
                    ]
                }
