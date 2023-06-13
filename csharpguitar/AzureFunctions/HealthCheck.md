<properties
  articleid="..."
  cloudenvironments="public,mooncake,fairfax,usnat,ussec"
  description="Health Check related failure - Azure App Service Web App: Availability, Performance, and Application Issues"
  isofficial="True"
  ms.author="benperk"
  ownershipid="Compute_AppService"
  pagetitle="Spark Unexpected Result"
  problemids=""
  productpesids="..."
  resourcerequired="False"
  resourcetags=""
  selfhelptype="apollo"
  supporttopicids="..." />
# Azure App Service : Health Check related failure
Here you will find related documentation concerning the Health Check feature.  There also exists documentation concerning common Health Check behaviours with associated explainations, configuration recommendations and known issues.
## Monitor App Service instances using Health check
https://learn.microsoft.com/en-us/azure/app-service/monitor-instances-health-check
## Health check ->Environment variables and app settings in Azure App Service
https://learn.microsoft.com/en-us/azure/app-service/reference-app-settings?#health-check
## What App Service does with Health checks
https://learn.microsoft.com/en-us/azure/app-service/monitor-instances-health-check?#what-app-service-does-with-health-checks
## Health Check FAQs
https://learn.microsoft.com/en-us/azure/app-service/monitor-instances-health-check?#frequently-asked-questions
## Most common reasons for Health Check not replacing an unhealthy instance
-	Health Check will only replace instances up to the percentage specified on the WEBSITE_HEALTHCHECK_MAXUNHEALTHYWORKERPERCENT app setting (50% by default). 
For more information: [What if all my instances are unhealthy?](https://learn.microsoft.com/en-us/azure/app-service/monitor-instances-health-check?tabs=dotnet#what-if-all-my-instances-are-unhealthy)
-	At most one instance will be replaced per hour, with a maximum of three instances per day per App Service Plan. 
For more information: [What App Service does with Health checks](https://learn.microsoft.com/en-us/azure/app-service/monitor-instances-health-check?tabs=dotnet#what-app-service-does-with-health-checks)
-	When an app on an instance remains unhealthy for over one hour, the instance will only be replaced ONLY if all other apps with Health check enabled in the App Service Plan are also unhealthy.
For more information: [What if I have multiple apps on the same App Service Plan?](https://learn.microsoft.com/en-us/azure/app-service/monitor-instances-health-check?tabs=dotnet#what-if-i-have-multiple-apps-on-the-same-app-service-plan)
-	Your ASP is running on an ASEv2. 
For more information: [Does Health Check work on App Service Environments?](https://learn.microsoft.com/en-us/azure/app-service/monitor-instances-health-check?tabs=dotnet#does-health-check-work-on-app-service-environments)
-	The scale unit hosting your App Service Plan has reached its instance replacement limit for Health Check. For more information: <Raluca is working on getting this added to the public facing documentation>.
-	Your App Service Plan is running on Free or Shared. Since Free or Shared sites can’t scale, any unhealthy instances won’t be replaced by Health Check. 
For more information: [Limitations](https://learn.microsoft.com/en-us/azure/app-service/monitor-instances-health-check?tabs=dotnet#limitations)
  
