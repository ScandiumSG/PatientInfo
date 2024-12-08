import { useState, useEffect } from "react";
import ListView from "../components/ListView/ListView";
import { GetPatientEndpoint, GetSearchEndpoint } from "../util/ConnectionUtil";
import CreateForm from "../components/CreateForm/CreateForm";

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
            .then((res) => setPatientData(res));
    };

    const fetchSearch = async (name) => {
        const opt = {
            Method: "POST",
        };
        await fetch(GetSearchEndpoint, opt);
    };

    useEffect(() => {
        triggerFetch();
    }, [searchInfo]);

    return (
        <div>
            <CreateForm />
            <ListView listData={patientData} />
        </div>
    );
};

export default ListPage;
