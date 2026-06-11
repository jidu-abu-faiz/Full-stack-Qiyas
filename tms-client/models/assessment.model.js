export function calculateGrade(item) {
    switch (item.kind) {
        case "quiz":
            if (item.totalQuestions === 0) {
                return 0;
            }
            return Math.round((item.correctAnswers / item.totalQuestions) * 100);
        case "lab":
            return Math.round((item.functionalityScore + item.codeQualityScore) / 2);
        default: {
            const _check = item;
            throw new Error(`Unhandled assessment: ${JSON.stringify(_check)}`);
        }
    }
}
//# sourceMappingURL=assessment.model.js.map