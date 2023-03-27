import { Grid, List } from 'semantic-ui-react';
import { Category } from '../../../app/models/category';

interface Props {
	categories: Category[];
}

function CategoryDashboard({ categories }: Props) {
	return (
		<Grid>
			<Grid.Column width='10'>
				<List>
					{categories &&
						categories.map((category) => (
							<List.Item key={category.id}>
								<List.Icon name='angle right' />
								<List.Content content={category.title} />
							</List.Item>
						))}
				</List>
			</Grid.Column>
		</Grid>
	);
}

export default CategoryDashboard;
