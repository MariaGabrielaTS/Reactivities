import React, { useEffect, useState } from 'react';
// import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const[activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => {
      // console.log(response);
      setActivities(response.data);
    })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' />
        <List>
          {activities.map((activity: any) => (
              <List.Item key={activity.id}>
                {activity.title}
              </List.Item>
          ))}
        </List>
        {/* <ul>
          map function accepts callback for each element inside on array so we can do something with it
          {activities.map((activity: any) => (
            <li key={activity.id}>
              {activity.title}
            </li>
          ))}
        </ul> */}
    </div>
  );
}

export default App;
