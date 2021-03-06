package br.com.flaviogf.algamoneyapi.resources;

import br.com.flaviogf.algamoneyapi.models.Person;
import br.com.flaviogf.algamoneyapi.repositories.PersonRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/people/{id}/activate")
public class ActivatePersonResource {
    private final PersonRepository personRepository;

    @Autowired
    public ActivatePersonResource(PersonRepository personRepository) {
        this.personRepository = personRepository;
    }

    @PostMapping
    @PreAuthorize("hasRole('CREATE_PERSON')")
    public ResponseEntity<Void> store(@PathVariable Long id) {
        Optional<Person> optional = personRepository.findById(id);

        if (!optional.isPresent()) {
            return ResponseEntity.notFound().build();
        }

        Person person = optional.get();

        person.setActive(true);

        personRepository.save(person);

        return ResponseEntity.noContent().build();
    }

    @DeleteMapping
    @PreAuthorize("hasRole('CREATE_PERSON')")
    public ResponseEntity<Void> destroy(@PathVariable Long id) {
        Optional<Person> optional = personRepository.findById(id);

        if (!optional.isPresent()) {
            return ResponseEntity.notFound().build();
        }

        Person person = optional.get();

        person.setActive(false);

        personRepository.save(person);

        return ResponseEntity.noContent().build();
    }
}
