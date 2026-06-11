//import { Temporal } from "@js-temporal/polyfill";
//import  { Student } from "./models/student.model.js";

//const student: Student = {
//   id: "STU-001",
//    name: "Hana Tadesse",
//    enrollmentDate: Temporal.Now.instant(),
//};

// Try these what does the compiler say?
//student.id = "STU-999";
//console.log(student.gpa.toFixed(2));
//console.log(student.gpa?.toFixed(2) ?? "Not yet graded");

//..... exercise 3

//import { isStudent } from "./models/student.model.js";
//
//function processStudent(raw: unknown) {
//    if (isStudent(raw)) {
//        const gpaDisplay =
//            raw.gpa?.toFixed(2) ?? "Not yet graded";
//
//        console.log(
//            `Student ${raw.name} GPA: ${gpaDisplay}`
//        );
//    } else {
//        console.error("Invalid student data received");
//    }
//}
//
//processStudent({
//    id: "STU-001",
//    name: "Hana",
//    gpa: 3.7
//});
//
//processStudent(42);

//..... exercise 3B...

//import { parseStudent } from "./models/student.model.js";
//
//console.log(
//    parseStudent({
//        id: "STU-001",
//        name: "Hana",
//    })
//);
//
//parseStudent({
//    id: 42,
//    name: "Test",
//});

//......session 2 exercise 4 ....

import {
    AssessmentItem,
    calculateGrade,
} from "./models/assessment.model.js";

const quiz: AssessmentItem = {
    id: "QUIZ-001",
    kind: "quiz",
    title: "SQL Basics",
    correctAnswers: 8,
    totalQuestions: 10,
};

const lab: AssessmentItem = {
    id: "LAB-001",
    kind: "lab",
    title: "REST API Project",
    functionalityScore: 85,
    codeQualityScore: 90,
};

console.log(`Quiz grade: ${calculateGrade(quiz)}%`);
console.log(`Lab grade: ${calculateGrade(lab)}%`);