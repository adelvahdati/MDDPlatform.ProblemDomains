# MDDPlatform.ProblemDomains

1- Inside MDDPlatform.ProblemDomains.Api run this command to publish the project
dotnet publish -c Release -o app/publish

2- In the folder that contains your Dockerfile run this command to build your image
docker build -t problemdomainservice .


3- Run this command to create a container in a user-defined network
docker run -d --network mddplatform -p 5292:80 --name problemdomains-service problemdomainservice



