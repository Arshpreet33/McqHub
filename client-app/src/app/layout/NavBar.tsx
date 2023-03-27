import { Button, Container, Menu } from 'semantic-ui-react';

function NavBar() {
	return (
		<Menu inverted fixed='top'>
			<Container>
				<Menu.Item header>
					<img src='assets/logo.png' alt='logo' style={{ marginRight: '10px' }} />
					Mcq Hub
				</Menu.Item>
				<Menu.Item name='Categories' />
				<Menu.Item>
					<Button positive content='Start Test' />
				</Menu.Item>
			</Container>
		</Menu>
	);
}

export default NavBar;
