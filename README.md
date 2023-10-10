# CKBox ASP.NET Core example

This repository contains an example of a ASP.NET Core application that integrates CKBox and covers the popular usage scenarios.

The full guide describing the code of this example can be found [in the CKBox Documentation](https://ckeditor.com/docs/ckbox/latest/guides/integrations/frameworks/aspdotnetcore.html).

## Prerequisites
To run this example you will need access credentials required to connect to the CKBox service that you can obtain in the [CKEditor Ecosystem dashboard](https://dashboard.ckeditor.com/login).

## Running the application

1. Clone this repository.
2. Enter the project directory.
3. Add access credentials to the `appsettings.json` file.

   ```
   # appsettings.json
  "CKBoxAccessKey": "REPLACE-WITH-ACCESS-KEY",
  "CKBoxEnvironmentId": "REPLACE-WITH-ENVIRONMENT-ID",
   ```

4. Run the application.

   ```bash
   dotnet run
   ```

5. Open [http://localhost:5063](http://localhost:5063).
