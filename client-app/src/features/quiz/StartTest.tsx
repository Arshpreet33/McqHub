import axios from 'axios';
import { useEffect, useState } from 'react';
import { Card, Grid, Item } from 'semantic-ui-react';
import { Question } from '../../app/models/question';

interface Props {
	topic?: string;
}

function StartTest({ topic }: Props) {
	const [questions, setQuestions] = useState<Question[]>([]);

	useEffect(() => {
		axios.get<Question[]>(`http://localhost:5000/questions/${topic}`).then((response) => {
			console.log(response.data);
			setQuestions(response.data);
		});
		// setQuestions([
		// 	{
		// 		id: '1',
		// 		title: 'What is CSS',
		// 		description: 'A file with .css extension',
		// 		isActive: true,
		// 		selectedAnswer: null,
		// 		options: [
		// 			{ id: '1', title: 'A back-end programming language' },
		// 			{ id: '2', title: 'An HTML framework' },
		// 			{ id: '3', title: 'An HTML styling language' },
		// 			{ id: '4', title: 'None of the above' },
		// 		],
		// 	},
		// 	{
		// 		id: '2',
		// 		title: 'What is HTML',
		// 		description: '',
		// 		isActive: true,
		// 		selectedAnswer: null,
		// 		options: [
		// 			{ id: '1', title: 'Hello Text Markup Language' },
		// 			{ id: '2', title: 'Hyper Text Markup Language' },
		// 			{ id: '3', title: 'Hyper Test Markup Language' },
		// 			{ id: '4', title: 'None of the above' },
		// 		],
		// 	},
		// ]);
	}, [topic]);

	return (
		<Grid>
			<Grid.Column width='10'>
				<Item.Group>
					{questions &&
						questions.map((question) => (
							<Item key={question.id}>
								<Item.Content>
									<Item.Header as='h1'>Question No {question.id} - </Item.Header>
									<Item.Header as='h2'>{question.title}</Item.Header>
									<Item.Meta></Item.Meta>
									{question.description && <Item.Extra>{question.description}</Item.Extra>}
									<Item.Description>
										<Card.Group>
											{question.options &&
												question.options.map((option) => (
													<Card fluid color='red' key={option.id} header={option.title} />
												))}
										</Card.Group>
									</Item.Description>
								</Item.Content>
							</Item>
						))}
				</Item.Group>
			</Grid.Column>
		</Grid>
	);
}

export default StartTest;
