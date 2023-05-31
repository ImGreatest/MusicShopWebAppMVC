--
-- PostgreSQL database dump
--

-- Dumped from database version 15.0
-- Dumped by pg_dump version 15.0

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Album; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Album" (
    "Id" integer NOT NULL,
    "NameAlbum" text,
    "CountryIssue" text,
    "CountSongs" integer,
    "Issue" date
);


ALTER TABLE public."Album" OWNER TO postgres;

--
-- Name: Condition; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Condition" (
    "Id" text NOT NULL
);


ALTER TABLE public."Condition" OWNER TO postgres;

--
-- Name: Country; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Country" (
    "NameCountry" text NOT NULL
);


ALTER TABLE public."Country" OWNER TO postgres;

--
-- Name: Label; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Label" (
    "NameLabel" text NOT NULL
);


ALTER TABLE public."Label" OWNER TO postgres;

--
-- Name: Performer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Performer" (
    "Id" integer NOT NULL,
    "Name" text
);


ALTER TABLE public."Performer" OWNER TO postgres;

--
-- Name: Product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Product" (
    "Id" integer NOT NULL,
    "TypeProduct" text,
    "Label" text,
    "Style" text,
    "Album" integer,
    "Performer" integer,
    "Condition" text,
    "Cost" integer
);


ALTER TABLE public."Product" OWNER TO postgres;

--
-- Name: Style; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Style" (
    "NameStyle" text NOT NULL
);


ALTER TABLE public."Style" OWNER TO postgres;

--
-- Name: TypeProduct; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TypeProduct" (
    "TypeName" text NOT NULL
);


ALTER TABLE public."TypeProduct" OWNER TO postgres;

--
-- Data for Name: Album; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Album" ("Id", "NameAlbum", "CountryIssue", "CountSongs", "Issue") FROM stdin;
1	Goodbye & Good Riddance	usa	15	2023-05-24
\.


--
-- Data for Name: Condition; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Condition" ("Id") FROM stdin;
string2
\.


--
-- Data for Name: Country; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Country" ("NameCountry") FROM stdin;
str1ng1111
string
usa
\.


--
-- Data for Name: Label; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Label" ("NameLabel") FROM stdin;
string
\.


--
-- Data for Name: Performer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Performer" ("Id", "Name") FROM stdin;
1	Juice WRLD
\.


--
-- Data for Name: Product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Product" ("Id", "TypeProduct", "Label", "Style", "Album", "Performer", "Condition", "Cost") FROM stdin;
1	string	string	string	1	1	string2	5000
\.


--
-- Data for Name: Style; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Style" ("NameStyle") FROM stdin;
string
\.


--
-- Data for Name: TypeProduct; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TypeProduct" ("TypeName") FROM stdin;
string
\.


--
-- Name: Album albom_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Album"
    ADD CONSTRAINT albom_pkey PRIMARY KEY ("Id");


--
-- Name: Condition condition_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Condition"
    ADD CONSTRAINT condition_pkey PRIMARY KEY ("Id");


--
-- Name: Country country_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Country"
    ADD CONSTRAINT country_pkey PRIMARY KEY ("NameCountry");


--
-- Name: Label label_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Label"
    ADD CONSTRAINT label_pkey PRIMARY KEY ("NameLabel");


--
-- Name: Performer performer_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Performer"
    ADD CONSTRAINT performer_pkey PRIMARY KEY ("Id");


--
-- Name: Product product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_pkey PRIMARY KEY ("Id");


--
-- Name: Style style_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Style"
    ADD CONSTRAINT style_pkey PRIMARY KEY ("NameStyle");


--
-- Name: TypeProduct type_product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TypeProduct"
    ADD CONSTRAINT type_product_pkey PRIMARY KEY ("TypeName");


--
-- Name: Album albom_country_issue_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Album"
    ADD CONSTRAINT albom_country_issue_fkey FOREIGN KEY ("CountryIssue") REFERENCES public."Country"("NameCountry");


--
-- Name: Product product_albom_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_albom_fkey FOREIGN KEY ("Album") REFERENCES public."Album"("Id");


--
-- Name: Product product_albom_fkey1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_albom_fkey1 FOREIGN KEY ("Album") REFERENCES public."Album"("Id");


--
-- Name: Product product_condition_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_condition_fkey FOREIGN KEY ("Condition") REFERENCES public."Condition"("Id");


--
-- Name: Product product_condition_fkey1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_condition_fkey1 FOREIGN KEY ("Condition") REFERENCES public."Condition"("Id");


--
-- Name: Product product_label_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_label_fkey FOREIGN KEY ("Label") REFERENCES public."Label"("NameLabel");


--
-- Name: Product product_label_fkey1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_label_fkey1 FOREIGN KEY ("Label") REFERENCES public."Label"("NameLabel");


--
-- Name: Product product_performer_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_performer_fkey FOREIGN KEY ("Performer") REFERENCES public."Performer"("Id");


--
-- Name: Product product_performer_fkey1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_performer_fkey1 FOREIGN KEY ("Performer") REFERENCES public."Performer"("Id");


--
-- Name: Product product_style_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_style_fkey FOREIGN KEY ("Style") REFERENCES public."Style"("NameStyle");


--
-- Name: Product product_style_fkey1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_style_fkey1 FOREIGN KEY ("Style") REFERENCES public."Style"("NameStyle");


--
-- Name: Product product_type_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_type_fkey FOREIGN KEY ("TypeProduct") REFERENCES public."TypeProduct"("TypeName");


--
-- Name: Product product_type_fkey1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT product_type_fkey1 FOREIGN KEY ("TypeProduct") REFERENCES public."TypeProduct"("TypeName");


--
-- PostgreSQL database dump complete
--

