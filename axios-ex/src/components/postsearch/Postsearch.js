import axios from 'axios';
import React, { useState } from 'react';

const PostSearch = () => {
  const [postId, setPostId] = useState(0);
  const [postData, setPostData] = useState({});

  const handleChange = (event) => {
    setPostId(event.target.value);
  };

  const show = () => {
    let pid = parseInt(postId);
    axios
      .get(`https://jsonplaceholder.typicode.com/posts/${pid}`)
      .then((response) => {
        setPostData(response.data);
      })
      .catch((error) => {
        console.error('Error fetching post:', error);
      });
  };

  return (
    <div>
      <label>Post ID: </label>
      <input
        type="number"
        name="postId"
        value={postId}
        onChange={handleChange}
      />{' '}
      <br />
      <input type="button" value="Show" onClick={show} />
      <hr />
      Post ID: <b>{postData.id}</b> <br />
      Title: <b>{postData.title}</b> <br />
      Body: <b>{postData.body}</b>
    </div>
  );
};

export default PostSearch;