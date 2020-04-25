# Client

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 9.0.1.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

## Setting up Project

Run Infrastructure context with command 

```dotnet ef migrations add OrderEntityAdded -p .\Infrastructure\ -s .\API\ -c EcommerceContext```

- It should give below output

![image](https://user-images.githubusercontent.com/3886381/80276150-3eb6ae80-8704-11ea-8661-b889357a71d0.png)

- Then run dotnet watch run to apply migrations and check any error in case if any. This should create the database table ecommerce.db.

- It created required tables as shown below.

![image](https://user-images.githubusercontent.com/3886381/80276259-285d2280-8705-11ea-8565-407a6ce2a1a7.png)

- For removing the migration, you can use following command. Make sure to execute this only if you want change any migration.

```dotnet ef migrations remove -p .\Infrastructure\ -s .\API\ -c EcommerceContext```

- If you applied ```dotnet watch run``` then consider updating the database rather removing as database changes applied already.

dotnet ef database drop -p .\Infrastructure\ -s .\API\ -c EcommerceContext

dotnet ef migrations add OrderEntityAdded -p .\Infrastructure\ -s .\API\ -o .\Infrastructure\Migrations\  -c EcommerceContext