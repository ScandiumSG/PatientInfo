import { useState, useEffect } from "react";
import ListView from "../components/ListView/ListView";
import { GetPatientEndpoint, GetSearchEndpoint } from "../util/ConnectionUtil";
import CreateForm from "../components/CreateForm/CreateForm";
import SearchField from "../components/CreateForm/SearchField/SearchField";

const ListPage = () => {
    const [patientData, setPatientData] = useState([]);
    const [searchInfo, setSearchInfo] = useState("");

    const triggerFetch = () => {
        if (searchInfo !== "") {
            fetchSearch(searchInfo);
        } else {
            fetchAll();
        }
    };

    const fetchAll = async () => {
        await fetch(GetPatientEndpoint())
            .then((res) => res.json())
            .then((res) => setPatientData([...res]));
    };

    const fetchSearch = async (searchTerm) => {
        const searchData = {
            name: searchTerm,
        };

        const opt = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(searchData),
        };

        await fetch(GetSearchEndpoint(), opt)
            .then((res) => res.json())
            .then((res) => setPatientData([...res]));
    };

    useEffect(() => {
        triggerFetch();
    }, [searchInfo]);

    return (
        <div>
            <CreateForm refetch={triggerFetch} />
            <SearchField value={searchInfo} change={setSearchInfo} />
            <ListView refetch={triggerFetch} listData={patientData} />
        </div>
    );
};

export default ListPage;
