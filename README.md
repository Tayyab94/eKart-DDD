# eKart

eKart is an e-commerce application designed to provide a seamless shopping experience. This repository contains the source code for the eKart application, including the presentation layer, domain models, infrastructure, and application setup.

## Features

- Product management
- Database integration with Entity Framework Core
- Configurable options for database settings
- Value object converters
- Validation results for domain operations

## Project Structure

- `eKart_App/`: Contains the application entry point and configuration files.
- `eKart.Presentation/`: Contains the presentation layer, including controllers, views, and framework setup.
- `eKart.Domain/`: Contains the domain models and value objects.
- `eKart.Infrastructure/`: Contains infrastructure-related code, such as database options and extensions.

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQL Server

### Installation

1. Clone the repository:

git clone https://github.com/yourusername/eKart.git
cd eKart

2. Restore the dependencies:
   dotnet restore

3. Update the `appsettings.json` file in the `eKart_App` directory with your database connection string:

   {
  "ConnectionStrings": {
    "DefaultConnection": "YourConnectionStringHere"
  },
  "DatabaseOptions": {
    "ConnectionString": "YourConnectionStringHere",
    "CommandTimeout": 30,
    "MaxRetryCount": 5,
    "MaxRetryDelay": 30
  }
}


### Running the Application

1. Build the solution:
    dotnet build

2. Run the application:
   dotnet run --project eKart_App


## Usage

### Registering the Database

The `RegisterDatabase` extension method in `DatabaseRegisterExtensions.cs` sets up the database context with the necessary options:


public static IServiceCollection RegisterDatabase(this IServiceCollection services) { services.AddDbContextPool<EKartContext>((serviceProvider, options) => { var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
    options.UseSqlServer(databaseOptions.ConnectionString!, opt =>
    {
        opt.CommandTimeout(databaseOptions.CommandTimeout);
        opt.EnableRetryOnFailure(databaseOptions.MaxRetryCount,
            TimeSpan.FromSeconds(databaseOptions.MaxRetryDelay), Array.Empty<int>());
    });
});

return services;
}


### Configuring Database Options

The `DatabaseOptionsSetup.cs` file in the `eKart.Infrastructure` project configures the database options:


public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions> { public void Configure(DatabaseOptions options) { // Configure your database options here } }


## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

    
