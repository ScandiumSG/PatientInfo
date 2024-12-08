const GetBaseUrl = () => {
    return "https://localhost:7210/";
};

export const GetPatientEndpoint = () => {
    const pathString = GetBaseUrl().toString() + "patient/";
    return pathString;
};

export const GetSearchEndpoint = () => {
    const pathString = GetBaseUrl().toString() + "patient/search/";
    return pathString;
};
