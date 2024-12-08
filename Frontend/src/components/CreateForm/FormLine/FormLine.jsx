const FormLine = ({ node, handleFormChange, type }) => {
    if (node === undefined) {
        return;
    }

    return (
        <div>
            <span>{node[0]}: </span>
            <input
                type={type}
                onChange={(e) => handleFormChange(e, node[0])}
                value={node[1]}
            ></input>
        </div>
    );
};

export default FormLine;
