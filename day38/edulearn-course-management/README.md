# EduLearn Course Management SPA

## Installation

1. Install Angular CLI

npm install -g @angular/cli

2. Install dependencies

npm install

3. Run application

ng serve

4. Open browser

http://localhost:4200

## Components

### CourseList Component
Displays available courses and View Details button.

### CourseDetail Component
Displays selected course information and allows editing the course title.

## Data Binding Used

### Property Binding

[selectedCourse]="selectedCourse"

Used to pass selected course data from App Component to CourseDetail Component.

### Event Binding

(courseSelected)="onCourseSelected($event)"

Used to capture button click events from CourseList Component.

### Two-Way Binding

[(ngModel)]="selectedCourse.title"

Used to edit the course title dynamically.

## Learning Outcome

- Angular Components
- Standalone Components
- Property Binding
- Event Binding
- Two-Way Binding
- Single Page Application (SPA)