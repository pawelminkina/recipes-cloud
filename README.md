# recipes-cloud
Plan is to create application, which will have recipies, display the list of thme, have ability of adding new one, option to return external links with recipies from outside, adding reviews of recipies by users. On the beginning without any auth, later I'll decide what to do with it.
![First architecture](./img/Plan-architecture.jpg)
Deploy to:
- Azure
- AWS
- GCP
- Docker with gRPC
# Cost
![koszt](./img/cost-azure.png)

##What is left:
- Whole external sites project
- External sites filler with time trigger
- Refactor in case of namespaces, common approach to everything I see
- Integration tests for all http request available
- Make schema how UI need to look
- Create most basic UI without styles which only gives all backend functionalities
- Style UI in most simple possible way existing, for example bootstrap
- If every step done, think about deployment (terraform, maybe that docker for local dev?)

Nice to do:
- Validators in mediator