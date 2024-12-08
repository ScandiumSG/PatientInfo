import { useState } from "react";

const FormConditions = ({ conditions, setConditions }) => {
    const [condition, setCondition] = useState("");

    const handleAddCondition = () => {
        if (condition.trim()) {
            setConditions([...conditions, condition]);
            setCondition("");
        }
    };

    /** Remove specific condition from the array */
    const handleRemoveCondition = (index) => {
        setConditions(conditions.filter((_, i) => i !== index));
    };

    return (
        <div>
            <input
                type="text"
                value={condition}
                onChange={(e) => setCondition(e.target.value)}
                placeholder="Enter a condition"
            />
            <button onClick={handleAddCondition}>Add Condition</button>
            <ul>
                {conditions.map((cond, index) => (
                    <li key={index}>
                        {cond}{" "}
                        <button onClick={() => handleRemoveCondition(index)}>
                            Remove
                        </button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default FormConditions;
