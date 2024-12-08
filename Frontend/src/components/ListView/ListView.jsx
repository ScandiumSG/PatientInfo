import ListNode from "./ListNode/ListNode";

const ListView = ({ refetch, listData }) => {
    if (listData.length === 0) {
        return (
            <div>
                <p>No patient records found.</p>
            </div>
        );
    }

    return (
        <div>
            <h3>Patients</h3>
            {listData.map((node, index) => (
                <ListNode refetch={refetch} data={node} key={index} />
            ))}
        </div>
    );
};

export default ListView;
