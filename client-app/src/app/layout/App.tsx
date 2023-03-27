import { useEffect, useState } from 'react';
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import { Category } from '../models/category';
import NavBar from './NavBar';
import CategoryDashboard from '../../features/categories/dashboard/CategoryDashboard';
import StartTest from '../../features/quiz/StartTest';

function App() {
	const [categories, setCategories] = useState<Category[]>([]);

	useEffect(() => {
		axios.get<Category[]>('http://localhost:5000/categories').then((response) => {
			setCategories(response.data);
		});
	}, []);

	return (
		<>
			<NavBar />
			<Container style={{ marginTop: '7em' }}>
				<CategoryDashboard categories={categories} />
				<StartTest />
			</Container>
		</>
	);
}

export default App;
