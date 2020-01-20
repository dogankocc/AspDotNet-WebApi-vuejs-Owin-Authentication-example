1. New Project > Visual C# > Asp .Net Web Application > Empty and select WebApi > Ok
And  config.EnableCors(); Add to WebApiConfig ,
2. Right Click Models , Add new item and select data and ADO NET Entity Model and make connetion configuration and select sql tables,procedures ...
3. Install these nuget packages:
Microsoft.AspNet.WebApi.Cors
Microsoft.Owin.Host.SystemWeb
Microsoft.Owin.Security.OAuth
Microsoft.Owin.Security.Cookies
Microsoft.Owin.Cors
Newtonsoft.json
4. Solution Explorer > Right Click on Project Name form the Solution Explorer > Add > New Item > class > Enter the class name as Startup.cs > and then click on the Add
5. Add current codes in Startup 
6. Models > Right Click > Add > New Item > class > AuthorizationServerProvider > Add current codes in AuthorizationServerProvider
7. Do same process for ClientMasterRepository ,ClientMasterRepository ,UserMasterRepository
