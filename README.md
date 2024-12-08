# PatientInfo

## Technology

The backend is created using C# and .NET 8, with Entity framework core InMemory database for datastorage.

The frontend is created using React through Vite.

## How to run

The quickest and recommended way to run is to open the solution (.sln) file in Visual Studio and running the default multi-prosject startup configuration (F5) that starts the backend and frontend. The backend would then be available on `https://localhost:7210` and frontend available on `https://localhost:63237/`.

### Alternatives, which would require changing listening ports

Alternativly the backend can be started from the backend directory by using the commands:

```
cd Backend
dotnet run
```

The frontend can be started from the frontend directory by using the commands:

```
cd frontend
npm install
npm run build
npm run preview
```

As the backend would then use default ports, which might be occupied the frontend, the `./src/util/ConnectionUtil.js` base url would need to be changed.

## Implementation notes

Error handling handled primarily by HTTP codes. Usage of REST API makes the usage of 4xx codes a quick and easy method of implementing error handling.

The frontend is a very quick, simple, and basic implementation. Just intended to quickly visualize and make the data available. Responsive design and accessibility has not been a focus due to limited time and scope of the project.
