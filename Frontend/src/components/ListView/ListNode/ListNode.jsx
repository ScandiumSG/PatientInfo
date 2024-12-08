import { useEffect, useState } from "react";
import styles from "./ListNode.module.css";
import { GetPatientEndpoint } from "../../../util/ConnectionUtil";

const ListNode = ({ refetch, data }) => {
    const [newCondition, setNewCondition] = useState("");
    const [editingConditions, setEditingConditions] = useState(false);
    const [localConditions, setLocalConditions] = useState(data.conditions);

    useEffect(() => {
        setLocalConditions(data.conditions);
    }, [data.conditions]);

    const handleDelete = async () => {
        const opt = {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
        };

        await fetch(GetPatientEndpoint() + `${data.id}`, opt)
            .then((res) => {
                if (res.status === 200) {
                    refetch();
                }
            })
            .catch((error) => {
                console.error("Error during delete:", error);
            });
    };

    const handleAddCondition = async () => {
        const updatedConditions = [...localConditions, newCondition];
        await updateBackendData(updatedConditions);
    };

    /**
     * Remove a string from the array of strings in localConditions
     * @param {The index of the string in the localCondition array to remove} index
     */
    const handleRemoveCondition = async (index) => {
        const updatedConditions = localConditions.filter((_, i) => i !== index);
        setLocalConditions(updatedConditions);
        await updateBackendData(updatedConditions);
    };

    /**
     * Change the value of a string at the targeted index of localConditions
     * @param {ChangeEvent} e Change event
     * @param {number} index Index in the localConditions array of the string to be changed
     */
    const handleUpdateCondition = async (e, index) => {
        localConditions[index] = e.target.value;
        setLocalConditions([...localConditions]);
        await updateBackendData(localConditions);
    };

    const handleToggleEdit = () => {
        setEditingConditions(!editingConditions);
    };

    const updateBackendData = async (conditionList) => {
        // PUT the updated condition
        const opt = {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                ...data,
                conditions: conditionList,
            }),
        };

        await fetch(GetPatientEndpoint(), opt)
            .then((res) => {
                if (res.status === 201) {
                    setLocalConditions(conditionList);
                    setNewCondition("");
                    refetch();
                }
            })
            .catch((error) => {
                console.error("Error during PUT:", error);
            });
    };

    return (
        <div className={styles.listNode}>
            <button className={styles.deleteButton} onClick={handleDelete}>
                X
            </button>

            <h3 className={styles.name}>{data.name}</h3>
            <p className={styles.age}>Age: {data.age}</p>
            <div className={styles.conditions}>
                <p>Conditions:</p>
                {editingConditions ? (
                    <div>
                        {localConditions.map((cond, index) => (
                            <div key={index}>
                                <input
                                    onChange={(e) =>
                                        handleUpdateCondition(e, index)
                                    }
                                    value={localConditions[index]}
                                ></input>
                                <button
                                    className={styles.removeButton}
                                    onClick={() => handleRemoveCondition(index)}
                                >
                                    X
                                </button>
                            </div>
                        ))}
                    </div>
                ) : (
                    <ul>
                        {localConditions.map((cond, index) => (
                            <li key={index}>{cond}</li>
                        ))}
                    </ul>
                )}

                {editingConditions && (
                    <div>
                        <input
                            type="text"
                            value={newCondition}
                            onChange={(e) => setNewCondition(e.target.value)}
                            placeholder="New condition"
                        />
                        <button onClick={handleAddCondition}>Add</button>
                    </div>
                )}

                <button onClick={handleToggleEdit}>
                    {editingConditions ? "Stop editing" : "Edit Conditions"}
                </button>
            </div>
        </div>
    );
};

export default ListNode;
