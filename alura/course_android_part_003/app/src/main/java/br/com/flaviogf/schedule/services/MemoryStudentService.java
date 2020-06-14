package br.com.flaviogf.schedule.services;

import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public class MemoryStudentService implements StudentService {
    private final static Map<UUID, Student> students = new HashMap<>();

    @Override
    public Result<Void> save(Student student) {
        students.put(student.getId(), student);

        return Result.ok();
    }

    @Override
    public Result<Void> remove(Student student) {
        students.remove(student.getId());

        return Result.ok();
    }

    @Override
    public Result<Collection<Student>> fetch() {
        Collection<Student> unmodifiableStudents = Collections.unmodifiableCollection(MemoryStudentService.students.values());

        return Result.ok(unmodifiableStudents);
    }

    @Override
    public Result<Student> fetchOne(UUID id) {
        if (!students.containsKey(id)) {
            return Result.fail("Student does not exist");
        }

        Student student = students.get(id);

        return Result.ok(student);
    }
}
