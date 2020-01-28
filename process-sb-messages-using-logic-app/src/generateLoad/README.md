# Generate load

At this point, you need to invoke the QueueMessage Azure function a sufficient number of times in order to generate enough test messages in the Service Bus queue.

One way you can do this is to use a tool such as [Artillery.io](https://artillery.io/docs/getting-started/). The yml script provided is an Artillery.io load script you can use to invoke the QueueMessage function a bunch of times in order to generate messages.  

You will need to update the target and url with your own Function App name and function authoriation code respectively before executing.  

Refer to the Artillery.io documentation if you want to tweak the settings, but generally you can increase the duration and arrivalRate to increase the number of messages that will be generated.  

Once you've installed the tool, you can execute the following from a PowerShell command prompt:  

**.\driver.ps1**  
