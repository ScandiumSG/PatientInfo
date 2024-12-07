namespace Backend.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieve a specific T object based on provided id
        /// </summary>
        /// <param name="id">The GUID id of the object to be retrieved</param>
        /// <returns>The found T object, null if no object with provided id found</returns>
        public Task<T?> GetSpecific(Guid id);

        /// <summary>
        /// Retrieve a list of all patients.
        /// </summary>
        /// <returns>List of T objects, if none found a empty list is returned</returns>
        public Task<List<T>> GetAll();

        /// <summary>
        /// Attempt to create a new object
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <returns>The created T object</returns>
        public Task<T?> Create(T entity);

        /// <summary>
        /// Attempt to update information for a provided object
        /// </summary>
        /// <param name="entity">The updated entity to save</param>
        /// <returns>The updated T object</returns>
        public Task<T?> Update(T entity);

        /// <summary>
        /// Attempt to delete the object based on its id
        /// </summary>
        /// <param name="id">A GUID id for the object to be deleted</param>
        /// <returns>The deleted object</returns>
        public Task<T?> Delete(T entity);
    }
}
