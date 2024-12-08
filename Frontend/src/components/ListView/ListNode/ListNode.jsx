import { useEffect, useState } from "react";
import styles from "./ListNode.module.css";
import { GetPatientEndpoint } from "../../../util/ConnectionUtil";

const ListNode = ({ refetch, data }) => {
    useEffect(() => {
        console.log(data);
    }, [data]);

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

    return (
        <div className={styles.listNode}>
            <button className={styles.deleteButton} onClick={handleDelete}>
                X
            </button>

            <h3 className={styles.name}>{data.name}</h3>
            <p className={styles.age}>Age: {data.age}</p>
            <div className={styles.conditions}>
                <p>Conditions: </p>
                <ul>
                    {data.conditions.map((cond, index) => (
                        <li key={index}>{cond}</li>
                    ))}
                </ul>
            </div>
        </div>
    );
};

export default ListNode;
