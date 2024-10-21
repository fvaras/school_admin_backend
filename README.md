# school_admin_backend
This backend project is designed to support a comprehensive frontend for school administrations, facilitating a variety of operations. The API utilizes .NET Core 6.0, EF (Entity Framework), and Dapper, known for their robustness, security, and scalability, thereby ensuring a reliable foundation for school management systems.

## Notes:
For the scaffolding of interfaces, services, data access layer, DTOs and mapping profiles I used ChatGPT 4 with a prompt that generates all of this from a Model definition.

## Important
Currently, the project is in the design phase. However, I have made it public so that you can view my work and progress.
The database I choose was Supabase, so you could experiment some delay in the responses from the API

## Tech stack
- C#
- AWS Lambda
- AWS S3
- AWS CLI
- Web API
- .NET Core 8.0
- EF Core (PSQL). I used to work with Dapper, but for this project I'm making experiments with EF
- Dapper
- AutoMapper
- NLog
- VS Code

# Test
## API
For demostrative purposes you can find the [API Swagger UI](https://p3epxit74fbyp7e4wihwvf3xbq0xhcmc.lambda-url.us-east-1.on.aws/swagger) (https://p3epxit74fbyp7e4wihwvf3xbq0xhcmc.lambda-url.us-east-1.on.aws/swagger)

## Frontend
You can test the API from this frontend system [SchoolAdmin](http://school-admin.s3-website-us-east-1.amazonaws.com) (http://school-admin.s3-website-us-east-1.amazonaws.com)

## Credentials
ADMINISTRATOR Profile:

    user 'admin'
    pass 'admin'

TEACHER Profile:

    user 'jpteacher'
    pass 'jpteacher'

STUDENT Profile:

    user 'lupita'
    pass 'lupita'

GUARDIAN Profile:

    user 'mdancer'
    pass 'mdancer'
