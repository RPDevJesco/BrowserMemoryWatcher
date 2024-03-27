# MWC Framework Performance Testing

This repository contains a C# application designed to test and monitor the performance of the Modular Web Component (MWC) framework. The MWC framework aims to provide a lightweight, efficient, and modular approach to building web components. This application evaluates the framework's performance by monitoring memory usage and other relevant metrics during the execution of web components built with MWC.

## Motivation

The motivation behind developing this application was to gain insights into how well the MWC framework performs under various conditions. By systematically testing the framework, we aim to identify areas of optimization, ensure stability, and improve the overall efficiency of web components developed using MWC.

## Installation

To set up the performance testing application on your local machine, follow these steps:

1. Ensure you have the .NET SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).

2. Clone this repository to your local machine using Git:

```bash
git clone https://github.com/RPDevJesco/BrowserMemoryWatcher.git
```

3. Navigate to the cloned repository's directory:

```bash 
cd mwc-performance-testing
```

4. Build the application:

```bash
dotnet build
```

5. Make sure the chromedriver and msedgedriver are in the bin folder


## Usage

To run the performance tests, follow these instructions:

1. Navigate to the application's directory if you're not already there.

2. Run the application:


```bash 
dotnet run
```

3. Follow the on-screen prompts to specify the browser type and URL (if testing web components in a browser environment).

The application will automatically monitor and log memory usage and other performance metrics as it interacts with the MWC framework.


## Contributing

Contributions to improve the performance testing application or the MWC framework are welcome. If you have suggestions or improvements, please follow these steps:

1. Fork the repository.

2. Create a new branch for your feature (`git checkout -b feature/AmazingFeature`).

3. Commit your changes (`git commit -m 'Add some AmazingFeature'`).

4. Push to the branch (`git push origin feature/AmazingFeature`).

5. Open a pull request.

## License

This project is licensed under the MIT License