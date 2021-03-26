function Book(props) {
    // if (!props.title) {
    //     return (
    //         <article>
    //             <p>No information provided</p>
    //         </article>
    //     );
    // }

    const author = props.author ? <strong>{props.author}</strong> : <strong>Pesho</strong>;
    
    return (
        <article>
            <h3 onClick={props.clickHandler}>{props.title ? <i>{props.title}</i> : 'No title Provided'}</h3>
            <p>{props.description || 'Default Description'}</p>
            <p>{author}</p>
        </article>
    );
}

export default Book;
