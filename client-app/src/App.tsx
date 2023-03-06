import './App.css';
import { useEffect, useState } from 'react';
import axios from 'axios';
import { Button, Header, List } from 'semantic-ui-react';

function App() {
	const [categories, setCategories] = useState([]);

	useEffect(() => {
		axios.get('http://localhost:5000/categories').then((response) => {
			setCategories(response.data);
			console.log(response.data);
		});
	}, []);

	return (
		<div className='App'>
			<Header as='h2' icon='list' content='Categories' />
			<List>
				{categories &&
					categories.map((category: any) => (
						<List.Item key={category.id}>
							<List.Icon name='angle right' />
							<List.Content content={category.title} />
						</List.Item>
					))}
			</List>
		</div>
	);
}

export default App;
