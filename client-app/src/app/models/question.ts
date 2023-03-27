import { QuestionOption } from './questionOption';

export interface Question {
	id: string;
	title: string;
	description: string;
	isActive: boolean;
	selectedAnswer: QuestionOption | null;
	options: QuestionOption[];
}
