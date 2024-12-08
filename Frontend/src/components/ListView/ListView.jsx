import ListNode from "./ListNode/ListNode";

const ListView = ({ listData }) => {
    if (listData.length == 0) {
        return (
            <div>
                <p>No patient records found.</p>
            </div>
        );
    }

    return (
        <div>
            {listData?.array?.forEach(node, (index) => {
                <ListNode data={node} key={index} />;
            })}
        </div>
    );
};

export default ListView;
