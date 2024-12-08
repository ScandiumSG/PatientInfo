import { useEffect, useState } from "react";
import FormLine from "./FormLine/FormLine";
import FormConditions from "./FormConditions/FormConditions";
import { GetPatientEndpoint } from "../../util/ConnectionUtil";

const formDataTemplate = {
    Name: "",
    DateOfBirth: "",
};

const CreateForm = () => {
    const [show, setShow] = useState(false);
    const [formData, setFormData] = useState(formDataTemplate);
    const [conditions, setConditions] = useState([]);

    const handleShowButtonInteraction = () => {
        setShow(!show);
    };

    const updateFormData = (e, field) => {
        setFormData({ ...formData, [field]: e.target.value });
    };

    const submitPatient = async () => {
        const patientInfo = {
            name: formData["Name"],
            dateOfBirth: formData["DateOfBirth"],
            conditions: conditions,
        };

        const opt = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(patientInfo),
        };

        await fetch(GetPatientEndpoint(), opt)
            .then((res) => {
                if (res.status === 201) {
                    setShow(false);
                    setConditions([]);
                    setFormData(formDataTemplate);
                }
            })
            .catch((error) => {
                console.error("Error:", error);
            });
    };

    if (!show) {
        return (
            <div>
                <button onClick={() => handleShowButtonInteraction()}>
                    Add patient
                </button>
            </div>
        );
    }

    return (
        <div>
            <div>
                <FormLine
                    node={Object.entries(formData)[0]}
                    handleFormChange={updateFormData}
                    type={"text"}
                />
                <FormLine
                    node={Object.entries(formData)[1]}
                    handleFormChange={updateFormData}
                    type={"date"}
                />
                <FormConditions
                    conditions={conditions}
                    setConditions={setConditions}
                />
            </div>
            <button onClick={() => submitPatient()}>Submit patient</button>
        </div>
    );
};

export default CreateForm;
