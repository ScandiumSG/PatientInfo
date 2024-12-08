const SearchField = ({ value, change }) => {
    const handleChange = (e) => {
        change(e.target.value);
    };
    return (
        <div>
            <p>Search by name:</p>
            <input value={value} onChange={(e) => handleChange(e)}></input>
        </div>
    );
};

export default SearchField;
