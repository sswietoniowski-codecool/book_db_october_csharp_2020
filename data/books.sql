DROP TABLE IF EXISTS book;
DROP TABLE IF EXISTS author;

CREATE TABLE author (
    id int IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(20) NOT NULL,
    last_name VARCHAR(20) NOT NULL,
    birth_date DATE NOT NULL
);

DROP TABLE IF EXISTS book;
CREATE TABLE book (
    id int IDENTITY(1,1) PRIMARY KEY,
	author_id int,
    FOREIGN KEY (author_id) REFERENCES author(id),
    title VARCHAR(40) NOT NULL
);

INSERT INTO author (first_name, last_name, birth_date) VALUES
    ('J.R.R.', 'Tolkien', '1982-01-03'),
    ('Douglas', 'Adams', '1952-03-11'),
    ('George R. R.', 'Martin', '1948-09-20'),
    ('Frank', 'Herbert', '1920-10-08')
;

INSERT INTO book (author_id, title) VALUES
    ((SELECT id FROM author WHERE last_name = 'Tolkien'), 'Hobbit'),
    ((SELECT id FROM author WHERE last_name = 'Tolkien'), 'Lord of the Rings'),
    ((SELECT id FROM author WHERE last_name = 'Adams'), 'Hitchhiker''s Guide to the Galaxy'),
    ((SELECT id FROM author WHERE last_name = 'Martin'), 'A Game of Thrones'),
    ((SELECT id FROM author WHERE last_name = 'Martin'), 'Tuf Voyaging'),
    ((SELECT id FROM author WHERE last_name = 'Herbert'), 'Dune')
;