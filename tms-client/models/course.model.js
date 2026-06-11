export function describeCourse(status) {
    switch (status.status) {
        case "DRAFT":
            return `Draft created by ${status.createdBy}`;
        case "PUBLISHED":
            return `Published with syllabus: ${status.syllabus}`;
        case "ACTIVE":
            return `Active with ${status.enrolledCount} students since ${status.startDate}`;
        case "ARCHIVED":
            return `Archived with ${status.finalEnrollmentCount} total enrollments`;
        case "CANCELLED":
            return `Cancelled: ${status.reason}`;
        default: {
            const _check = status;
            throw new Error(`Unhandled course status: ${JSON.stringify(_check)}`);
        }
    }
}
//# sourceMappingURL=course.model.js.map