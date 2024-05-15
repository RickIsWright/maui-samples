using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf.Exceptions;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

namespace QSF.Examples.AIPromptControl.FirstLookExample;

public class AiService
{
    private static readonly Dictionary<string, string> llm = new Dictionary<string, string>
    {
        { "S1_Default_English", "Key Points of a Well-Written CV:\r\n\r\n1. Use a clear and concise formatting style.\r\n2. Provide contact information. \r\n3. Provide a brief professional summary.\r\n4. List your work experience.\r\n5. Include your educational background.\r\n6. Highlight your key skills.\r\n7. Showcase your achievements or awards.\r\n\r\nTips:\r\n- Customize your CV for each job application to highlight the most relevant skills and experiences.\r\n- Use keywords from the job description to optimize your CV and to demonstrate alignment with the role.\r\n- Look through the CV in order to confirm there are no typos, grammatical errors, or format inconsistencies.\r\n- Seek advice from a trusted friend, mentor, or professional to review your CV and give you feedback before submitting to potential employers." },
        { "S1_Default_German", "Schlüsselpunkte eines gut geschriebenen Lebenslaufs:\r\n\r\n1. Verwenden Sie einen klaren und prägnanten Formatierungsstil.\r\n2. Geben Sie Ihre Kontaktdaten an. \r\n3. Verschaffen Sie einen kleinen beruflichen Überblick.\r\n4. Listen Sie Ihre Berufserfahrung auf.\r\n5. Fügen Sie Ihre Ausbildung hinzu.\r\n6. Heben Sie Ihre wichtigsten Fähigkeiten hervor.\r\n7. Präsentieren Sie Ihre Leistungen oder Auszeichnungen.\r\n\r\nTips:\r\n- Passen Sie Ihren Lebenslauf für jede Bewerbung an, um die relevantesten Fähigkeiten und Erfahrungen hervorzuheben.\r\n- Verwenden Sie Schlüsselwörter aus der Stellenbeschreibung, um Ihren Lebenslauf zu optimieren und eine Übereinstimmung mit der Rolle zu zeigen.\r\n- Überprüfen Sie den Lebenslauf, um sicherzustellen, dass keine Tippfehler, Grammatikfehler oder Formatinkonsistenzen vorliegen.\r\n- Holen Sie sich Ratschläge von einem vertrauenswürdigen Freund, Mentor oder Fachmann, um Ihren Lebenslauf zu überprüfen und Feedback zu erhalten, bevor Sie ihn potenziellen Arbeitgebern vorlegen." },
        { "S1_Default_Spanish", "Puntos Clave de un CV Bien Escrito:\r\n\r\n1. Utiliza un Formato Claro y Conciso.\r\n2. Proporciona Información de Contacto. \r\n3. Proporciona un Breve Resumen Profesional.\r\n4. Lista tu Experiencia Laboral.\r\n5. Incluye tu Formación Académica.\r\n6. Resalta tus Habilidades Clave.\r\n7. Muestra tus Logros o Premios.\r\n\r\nConsejos:\r\n- Adapta tu CV para cada solicitud de trabajo para resaltar las habilidades y experiencias más relevantes.\r\n- Utiliza palabras clave de la descripción del trabajo para optimizar tu CV y demostrar alineación con el rol.\r\n- Revisa el CV para confirmar que no haya errores tipográficos, errores gramaticales o inconsistencias de formato.\r\n- Busca consejo de un amigo de confianza, mentor o profesional para revisar tu CV y darte retroalimentación antes de enviarlo a posibles empleadores." },
        { "S1_Simplified_English", "Key Points of a Well-Written CV:\r\n\r\n1. Use a clear and concise formatting style.\r\n2. Provide contact information.\r\n3. Provide a brief professional summary.\r\n4. List your work experience.\r\n5. Include your educational background.\r\n6. Highlight your key skills.\r\n7. Showcase your achievements or awards." },
        { "S1_Simplified_German", "Schlüsselpunkte eines gut geschriebenen Lebenslaufs:\r\n\r\n1. Verwenden Sie einen klaren und prägnanten Formatierungsstil.\r\n2. Geben Sie Ihre Kontaktdaten an.\r\n3. Verschaffen Sie einen kleinen beruflichen Überblick.\r\n4. Listen Sie Ihre Berufserfahrung auf.\r\n5. Fügen Sie Ihre Ausbildung hinzu.\r\n6. Heben Sie Ihre wichtigsten Fähigkeiten hervor.\r\n7. Präsentieren Sie Ihre Leistungen oder Auszeichnungen." },
        { "S1_Simplified_Spanish", "Puntos Clave de un CV Bien Escrito:\r\n\r\n1. Utiliza un Formato Claro y Conciso.\r\n2. Proporciona Información de Contacto.\r\n3. Proporciona un Breve Resumen Profesional.\r\n4. Lista tu Experiencia Laboral.\r\n5. Incluye tu Formación Académica.\r\n6. Resalta tus Habilidades Clave.\r\n7. Muestra tus Logros o Premios." },
        { "S1_Expanded_English", "Key Points of a Well-Written CV:\r\n\r\n1. Use a clear and concise formatting style:\r\n- Use a clean and professional layout.\r\n- Keep your CV to a maximum of one or two pages.\r\n2. Contact Information:\r\n- Include your name, phone number, email address, and LinkedIn profile (if applicable).\r\n3. Professional summary/objective:\r\n- Provide a brief overview of your career goals, skills, and experience.\r\n4. Work experience:\r\n- List your work experience in opposite chronological order.\r\n- Include the job title, company name, location, and dates of employment for each position.\r\n5. Education:\r\n- Include your educational background and the name of the institution.\r\n6. Skills:\r\n- Highlight your key skills and competencies relevant to the job.\r\n7. Achievements and awards:\r\n- Showcase your achievements or awards you\'ve received in your career to demonstrate impact.\r\n8. Additional sections (optional):\r\n- Include additional sections such as certifications, professional memberships, volunteer experience, or language proficiency if relevant.\r\n\r\nThe above key points are very important, but tailoring your content is essential.\r\nCustomize your CV for each job application to highlight the most relevant skills and experiences.\r\nUse keywords from the job description to optimize your CV and to demonstrate alignment with the role.\r\n\r\nProofreading and editing are also a must.\r\nLook through the CV in order to confirm there are no typos, grammatical errors, or format inconsistencies.\r\nSeek advice from a trusted friend, mentor, or professional to review your CV and give you feedback before submitting to potential employers." },
        { "S1_Expanded_German", "Schlüsselpunkte eines gut geschriebenen Lebenslaufs:\r\n\r\n1. Verwenden Sie einen klaren und prägnanten Formatierungsstil:\r\n- Verwenden Sie ein sauberes und professionelles Layout.\r\n- Beschränken Sie Ihren Lebenslauf auf maximal eine oder zwei Seiten.\r\n2. Kontaktdaten:\r\n- Geben Sie Ihren Namen, Telefonnummer, E-Mail-Adresse und LinkedIn-Profil (falls vorhanden) an.\r\n3. Beruflicher Überblick/Ziel:\r\n- Geben Sie einen kurzen Überblick über Ihre Karriereziele, Fähigkeiten und Erfahrungen.\r\n4. Berufserfahrung:\r\n- Listen Sie Ihre Berufserfahrung in umgekehrter chronologischer Reihenfolge auf.\r\n- Enthalten Sie den Jobtitel, den Firmennamen, den Standort und die Beschäftigungszeiträume für jede Position.\r\n5. Ausbildung:\r\n- Fügen Sie Ihren Ausbildungshintergrund sowie den Namen der Institution hinzu.\r\n6. Fähigkeiten:\r\n- Heben Sie Ihre wichtigsten Fähigkeiten und Kompetenzen hervor, die für den Job relevant sind.\r\n7. Erfolge und Auszeichnungen:\r\n- Präsentieren Sie Ihre Erfolge oder Auszeichnungen, die Sie in Ihrer Karriere erhalten haben, um Ihre Wirkung zu zeigen.\r\n8. Zusätzliche Abschnitte (optional):\r\n- Fügen Sie zusätzliche Abschnitte wie Zertifizierungen, berufliche Mitgliedschaften, freiwillige Erfahrungen oder Sprachkenntnisse hinzu, wenn relevant.\r\n\r\nDie obigen Schlüsselpunkte sind sehr wichtig, aber die Anpassung des Inhalts ist entscheidend.\r\nPassen Sie Ihren Lebenslauf für jede Bewerbung an, um die relevantesten Fähigkeiten und Erfahrungen hervorzuheben.\r\nVerwenden Sie Schlüsselwörter aus der Stellenbeschreibung, um Ihren Lebenslauf zu optimieren und eine Übereinstimmung mit der Rolle zu zeigen.\r\n\r\nKorrekturlesen und Bearbeiten sind ebenfalls ein Muss.\r\nÜberprüfen Sie den Lebenslauf, um sicherzustellen, dass keine Tippfehler, Grammatikfehler oder Formatinkonsistenzen vorliegen.\r\nHolen Sie sich Ratschläge von einem vertrauenswürdigen Freund, Mentor oder Fachmann, um Ihren Lebenslauf zu überprüfen und Feedback zu erhalten, bevor Sie ihn potenziellen Arbeitgebern vorlegen." },
        { "S1_Expanded_Spanish", "Puntos Clave de un CV Bien Escrito:\r\n\r\n1. Utiliza un Formato Claro y Conciso:\r\n- Emplea un diseño limpio y profesional.\r\n- Mantén tu CV en un máximo de una o dos páginas.\r\n2. Información de Contacto:\r\n- Incluye tu nombre, número de teléfono, dirección de correo electrónico y perfil de LinkedIn (si corresponde).\r\n3. Resumen Profesional/Objetivo:\r\n- Proporciona una breve descripción de tus metas profesionales, habilidades y experiencia.\r\n4. Experiencia Laboral:\r\n- Enumera tu experiencia laboral en orden cronológico inverso.\r\n- Incluye el título del puesto, el nombre de la empresa, la ubicación y las fechas de empleo para cada posición.\r\n5. Educación:\r\n- Incluye tu formación académica y el nombre de la institución.\r\n6. Habilidades:\r\n- Destaca tus habilidades clave y competencias relevantes para el puesto.\r\n7. Logros y Premios:\r\n- Muestra tus logros o premios recibidos en tu carrera para demostrar impacto.\r\n8. Secciones Adicionales (Opcional):\r\n- Incluye secciones adicionales como certificaciones, membresías profesionales, experiencia como voluntario o habilidades lingüísticas si son relevantes.\r\n\r\nLos puntos clave anteriores son muy importantes, pero personalizar tu contenido es esencial.\r\nAdapta tu CV para cada solicitud de trabajo para resaltar las habilidades y experiencias más relevantes.\r\nUtiliza palabras clave de la descripción del trabajo para optimizar tu CV y demostrar alineación con el rol.\r\n\r\nLa corrección y edición también son fundamentales.\r\nRevisa el CV para confirmar que no haya errores tipográficos, errores gramaticales o inconsistencias de formato.\r\nBusca consejo de un amigo de confianza, mentor o profesional para revisar tu CV y darte retroalimentación antes de enviarlo a posibles empleadores." },
        { "S2_Default_English", "Below is a basic CV template that you can use as a starting point.\r\nRemember to customize it with your own information, experiences, and skills.\r\n\r\n1. Provide contact information:\r\n[Your Name, Address, City, State, ZIP Code, Phone Number, Email Address, LinkedIn Profile]\r\n \r\n2. Write a brief statement outlining your career goals or what you aim to achieve in your desired position.\r\n\r\n3. Your Education:\r\n[Degree], [University Name], [Graduation Date]\r\n\r\n4. Describe your work experience: \r\n[Job Title], [Company Name], [Location], [Dates of Employment]\r\n\r\n5. List your Skills:\r\n[Skill #1#2#3] & [Certification #1#2#3]\r\n\r\n6. Additional Information:\r\n[Languages spoken, if applicable]\r\n[Volunteer experience or community involvement, if applicable]" },
        { "S2_Default_German", "Nachfolgend finden Sie eine grundlegende Lebenslaufvorlage, die Sie als Ausgangspunkt verwenden können.\r\nDenken Sie daran, es mit Ihren eigenen Informationen, Erfahrungen und Fähigkeiten anzupassen.\r\n\r\n1. Geben Sie Ihre Kontaktdaten an:\r\n[Ihr Name, Adresse, Stadt, Bundesland, Postleitzahl, Telefonnummer, E-Mail-Adresse, LinkedIn-Profil]\r\n \r\n2. Schreiben Sie eine kurze Aussage, in der Ihre Berufsziele oder das, was Sie in der gewünschten Position erreichen möchten, skizziert werden.\r\n\r\n3. Ihre Ausbildung:\r\n[Abschluss], [Universitätsname], [Abschlussdatum]\r\n\r\n4. Beschreiben Sie Ihre Berufserfahrung: \r\n[Stellenbezeichnung], [Firmenname], [Ort], [Beschäftigungszeiträume]\r\n\r\n5. Listen Sie Ihre Fähigkeiten auf:\r\n[Fähigkeit #1#2#3] & [Zertifizierung #1#2#3]\r\n\r\n6. Zusätzliche Informationen:\r\n[Gesprochene Sprachen, wenn zutreffend]\r\n[Erfahrungen als Freiwilliger oder Engagement in der Gemeinde, wenn zutreffend]" },
        { "S2_Default_Spanish", "A continuación se muestra una plantilla básica de CV que puedes utilizar como punto de partida.\r\nRecuerda personalizarla con tu propia información, experiencias y habilidades.\r\n\r\n1. Proporcionar información de contacto:\r\n[Nombre Completo, Dirección, Ciudad, Estado, Código Postal, Teléfono, Correo Electrónico], Perfil de LinkedIn]\r\n \r\n2. Redacta un breve documento describiendo tus objetivos profesionales o lo que aspiras lograr en el puesto deseado.\r\n\r\n3. Educación:\r\n[Título], [Nombre de la Universidad], [Fecha de Graduación]\r\n\r\n4. Describe tu experiencia laboral: \r\n[Título del Trabajo], [Nombre de la Empresa], [Ubicación], [Fechas de Empleo]\r\n\r\n5. Enumera tus habilidades:\r\n[Habilidad #1#2#3] & [Certificación #1#2#3]\r\n\r\n6. Información adicional:\r\n[Idiomas hablados, si corresponde]\r\n[Experiencia como voluntario o participación comunitaria, si corresponde]" },
        { "S2_Simplified_English", "Below is a basic CV template that you can use as a starting point.\r\nRemember to customize it with your own information, experiences, and skills.\r\n\r\n1. Contact information.\r\n2. Objective.\r\n3. Your Education.\r\n4. A description of your work experience.\r\n5. A list of your Skills.\r\n6. Additional Information." },
        { "S2_Simplified_German", "Nachfolgend finden Sie eine grundlegende Lebenslaufvorlage, die Sie als Ausgangspunkt verwenden können.\r\nDenken Sie daran, es mit Ihren eigenen Informationen, Erfahrungen und Fähigkeiten anzupassen.\r\n\r\n1. Kontaktinformationen.\r\n2. Zielsetzung.\r\n3. Ihre Ausbildung.\r\n4. Eine Beschreibung Ihrer Berufserfahrung.\r\n5. Eine Liste Ihrer Fähigkeiten.\r\n6. Zusätzliche Informationen." },
        { "S2_Simplified_Spanish", "A continuación se muestra una plantilla básica de CV que puedes utilizar como punto de partida.\r\nRecuerda personalizarla con tu propia información, experiencias y habilidades.\r\n\r\n1. Información de Contacto.\r\n2. Objetivo.\r\n3. Educación.\r\n4. Una descripción de tu experiencia laboral.\r\n5. Una lista de tus Habilidades.\r\n6. Información Adicional." },
        { "S2_Expanded_English", "Below is an extended CV template that you can use as a starting point.\r\nRemember to customize it with your own information, experiences, and skills.\r\n\r\n[Contact Information]\r\n[Your Name]\r\n[Your Address]\r\n[City, State, ZIP Code]\r\n[Your Phone Number]\r\n[Your Email Address]\r\n[Your LinkedIn Profile (optional)]\r\n\r\nProfessional Summary:\r\n[Insert a brief summary highlighting your career goals, skills, and experiences.]\r\n\r\nWork Experience:\r\n- [Job Title]\r\n- [Company Name], [Location]\r\n- [Dates of Employment]\r\n\r\nEducation:\r\n- [Degree] in [Field of Study]\r\n- [University Name], [Location]\r\n- [Graduation Date or Expected Graduation Date]\r\n\r\nHigh School Diploma:\r\n- [High School Name], [Location]\r\n- [Graduation Date]\r\n\r\nSkills:\r\n- [Skill #1#2#3]\r\n\r\nCertifications (if applicable):\r\n- [Certification #1#2#3]\r\n\r\nProfessional Memberships (if applicable):\r\n- [Membership  #1#2#3]\r\n\r\nLanguages:\r\n- [Language #1]: [Proficiency Level]\r\n\r\nAdditional Information (optional):\r\n- [Volunteer Experience] & [Hobbies/Interests]\r\n\r\nFeel free to adjust and customize this template to best suit your needs and the requirements of the job you\'re applying for." },
        { "S2_Expanded_German", "Nachfolgend finden Sie eine erweiterte Lebenslaufvorlage, die Sie als Ausgangspunkt verwenden können.\r\nDenken Sie daran, es mit Ihren eigenen Informationen, Erfahrungen und Fähigkeiten anzupassen.\r\n\r\n[Kontaktinformationen]\r\n[Ihr Name]\r\n[Ihre Adresse]\r\n[Stadt, Bundesland, Postleitzahl]\r\n[Ihre Telefonnummer]\r\n[Ihre E-Mail-Adresse]\r\n[Ihr LinkedIn-Profil (optional)]\r\n\r\nBerufliche Zusammenfassung:\r\n[Fügen Sie eine kurze Zusammenfassung ein, die Ihre Karriereziele, Fähigkeiten und Erfahrungen hervorhebt.]\r\n\r\nBerufserfahrung:\r\n- [Berufsbezeichnung]\r\n- [Firmenname], [Ort]\r\n- [Beschäftigungszeiträume]\r\n\r\nAusbildung:\r\n- [Abschluss] in [Studiengang]\r\n- [Universitätsname], [Ort]\r\n- [Abschlussdatum oder Voraussichtliches Abschlussdatum]\r\n\r\nAbschlusszeugnis der Sekundarstufe:\r\n- [Name der High School], [Ort]\r\n- [Abschlussdatum]\r\n\r\nFähigkeiten:\r\n- [Fähigkeit #1#2#3]\r\n\r\nZertifizierungen (falls zutreffend):\r\n- [Zertifizierung #1#2#3]\r\n\r\nBerufliche Mitgliedschaften (falls zutreffend):\r\n- [Mitgliedschaft #1#2#3]\r\n\r\nSprachen:\r\n- [Sprache #1]: [Sprachkenntnisse]\r\n\r\nZusätzliche Informationen (optional):\r\n- [Ehrenamtliche Erfahrung] & [Hobbys/Interessen]\r\n\r\nZögern Sie nicht, diese Vorlage an Ihre Bedürfnisse und die Anforderungen der Stelle, auf die Sie sich bewerben, anzupassen." },
        { "S2_Expanded_Spanish", "A continuación se muestra una plantilla extendida de CV que puedes utilizar como punto de partida.\r\nRecuerda personalizarla con tu propia información, experiencias y habilidades.\r\n\r\n[Información de Contacto]\r\n[Nombre Completo]\r\n[Dirección]\r\n[Ciudad, Estado, Código Postal]\r\n[Teléfono]\r\n[Correo Electrónico]]\r\n[Perfil de LinkedIn (opcional)]\r\n\r\nResumen Profesional:\r\n[Inserta un breve resumen resaltando tus objetivos profesionales, habilidades y experiencias.]\r\n\r\nExperiencia Laboral:\r\n- [Título del Trabajo]\r\n- [Nombre de la Empresa], [Ubicación]\r\n- [Fechas de Empleo]\r\n\r\nEducación:\r\n- [Título] en [Campo de Estudio]\r\n- [Nombre de la Universidad], [Ubicación]\r\n- [Fecha de Graduación o Fecha de Graduación Esperada]\r\n\r\nDiploma de Escuela Secundaria:\r\n- [Nombre de la Escuela Secundaria], [Ubicación]\r\n- [Fecha de Graduación]\r\n\r\nHabilidades:\r\n- [Habilidad #1#2#3]\r\n\r\nCertificaciones (si corresponde):\r\n- [Certificación #1#2#3]\r\n\r\nMembresías Profesionales (si corresponde):\r\n- [Membresía  #1#2#3]\r\n\r\nIdiomas:\r\n- [Idioma #1]: [Nivel de Competencia]\r\n\r\nInformación Adicional (opcional):\r\n- [Experiencia Voluntaria] y [Pasatiempos/Intereses]\r\n\r\nSiéntete libre de ajustar y personalizar esta plantilla para que se adapte mejor a tus necesidades y a los requisitos del trabajo para el que estás aplicando." },
    };

    private static readonly Dictionary<string, string> llmHtml = new Dictionary<string, string>
    {
        { "S1_Default_English", "<p>Key Points of a Well-Written CV:</p><p>1. Use a clear and concise formatting style.<br>2. Provide contact information.<br>3. Provide a brief professional summary.<br>4. List your work experience.<br>5. Include your educational background.<br>6. Highlight your key skills.<br>7. Showcase your achievements or awards.</p><p>Tips:</p><p>- Customize your CV for each job application to highlight the most relevant skills and experiences.<br>- Use keywords from the job description to optimize your CV and to demonstrate alignment with the role.<br>- Look through the CV in order to confirm there are no typos, grammatical errors, or format inconsistencies.<br>- Seek advice from a trusted friend, mentor, or professional to review your CV and give you feedback before submitting to potential employers.</p>" },
        { "S1_Default_German", "<p>Schlüsselpunkte eines gut geschriebenen Lebenslaufs:</p><p>1. Verwenden Sie einen klaren und prägnanten Formatierungsstil.<br>2. Geben Sie Ihre Kontaktdaten an.<br>3. Verschaffen Sie einen kleinen beruflichen Überblick.<br>4. Listen Sie Ihre Berufserfahrung auf.<br>5. Fügen Sie Ihre Ausbildung hinzu.<br>6. Heben Sie Ihre wichtigsten Fähigkeiten hervor.<br>7. Präsentieren Sie Ihre Leistungen oder Auszeichnungen.</p><p>Tipps:</p><p>- Passen Sie Ihren Lebenslauf für jede Bewerbung an, um die relevantesten Fähigkeiten und Erfahrungen hervorzuheben.<br>- Verwenden Sie Schlüsselwörter aus der Stellenbeschreibung, um Ihren Lebenslauf zu optimieren und eine Übereinstimmung mit der Rolle zu zeigen.<br>- Überprüfen Sie den Lebenslauf, um sicherzustellen, dass keine Tippfehler, Grammatikfehler oder Formatinkonsistenzen vorliegen.<br>- Holen Sie sich Ratschläge von einem vertrauenswürdigen Freund, Mentor oder Fachmann, um Ihren Lebenslauf zu überprüfen und Feedback zu erhalten, bevor Sie ihn potenziellen Arbeitgebern vorlegen.</p>" },
        { "S1_Default_Spanish", "<p>Puntos Clave de un CV Bien Escrito:</p><p>1. Utiliza un Formato Claro y Conciso.<br>2. Proporciona Información de Contacto.<br>3. Proporciona un Breve Resumen Profesional.<br>4. Lista tu Experiencia Laboral.<br>5. Incluye tu Formación Académica.<br>6. Resalta tus Habilidades Clave.<br>7. Muestra tus Logros o Premios.</p><p>Consejos:</p><p>- Adapta tu CV para cada solicitud de trabajo para resaltar las habilidades y experiencias más relevantes.<br>- Utiliza palabras clave de la descripción del trabajo para optimizar tu CV y demostrar alineación con el rol.<br>- Revisa el CV para confirmar que no haya errores tipográficos, errores gramaticales o inconsistencias de formato.<br>- Busca consejo de un amigo de confianza, mentor o profesional para revisar tu CV y darte retroalimentación antes de enviarlo a posibles empleadores.</p>" },
        { "S1_Simplified_English", "<p>Key Points of a Well-Written CV:</p><p>1. Use a clear and concise formatting style.<br>2. Provide contact information.<br>3. Provide a brief professional summary.<br>4. List your work experience.<br>5. Include your educational background.<br>6. Highlight your key skills.<br>7. Showcase your achievements or awards.</p>" },
        { "S1_Simplified_German", "<p>Schlüsselpunkte eines gut geschriebenen Lebenslaufs:</p><p>1. Verwenden Sie einen klaren und prägnanten Formatierungsstil.<br>2. Geben Sie Ihre Kontaktdaten an.<br>3. Verschaffen Sie einen kleinen beruflichen Überblick.<br>4. Listen Sie Ihre Berufserfahrung auf.<br>5. Fügen Sie Ihre Ausbildung hinzu.<br>6. Heben Sie Ihre wichtigsten Fähigkeiten hervor.<br>7. Präsentieren Sie Ihre Leistungen oder Auszeichnungen.</p>" },
        { "S1_Simplified_Spanish", "<p>Puntos Clave de un CV Bien Escrito:</p><p>1. Utiliza un Formato Claro y Conciso.<br>2. Proporciona Información de Contacto.<br>3. Proporciona un Breve Resumen Profesional.<br>4. Lista tu Experiencia Laboral.<br>5. Incluye tu Formación Académica.<br>6. Resalta tus Habilidades Clave.<br>7. Muestra tus Logros o Premios.</p>" },
        { "S1_Expanded_English", "<p>Key Points of a Well-Written CV:</p><p>1. Use a clear and concise formatting style:<br>- Use a clean and professional layout.<br>- Keep your CV to a maximum of one or two pages.</p><p>2. Contact information:<br>- Include your name, phone number, email address, and LinkedIn profile (if applicable).</p><p>3. Professional summary/objective:<br>- Provide a brief overview of your career goals, skills, and experience.</p><p>4. Work experience:<br>- List your work experience in opposite chronological order.<br>- Include the job title, company name, location, and dates of employment for each position.</p><p>5. Education:<br>- Include your educational background and the name of the institution.</p><p>6. Skills:<br>- Highlight your key skills and competencies relevant to the job.</p><p>7. Achievements and awards:<br>- Showcase your achievements or awards you've received in your career to demonstrate impact.</p><p>8. Additional sections (optional):<br>- Include additional sections such as certifications, professional memberships, volunteer experience, or language proficiency if relevant.</p><p>The above key points are very important, but tailoring your content is essential.<br>Customize your CV for each job application to highlight the most relevant skills and experiences.<br>Use keywords from the job description to optimize your CV and to demonstrate alignment with the role.</p><p>Proofreading and editing are also a must.<br>Look through the CV in order to confirm there are no typos, grammatical errors, or format inconsistencies.<br>Seek advice from a trusted friend, mentor, or professional to review your CV and give you feedback before submitting to potential employers.</p>" },
        { "S1_Expanded_German", "<p>Schlüsselpunkte eines gut geschriebenen Lebenslaufs:</p><p>1. Klares und prägnantes Format:<br>- Verwenden Sie ein sauberes und professionelles Layout.<br>- Beschränken Sie Ihren Lebenslauf auf maximal eine oder zwei Seiten.</p><p>2. Kontaktdaten:<br>- Geben Sie Ihren Namen, Telefonnummer, E-Mail-Adresse und LinkedIn-Profil (falls vorhanden) an.</p><p>3. Beruflicher Überblick/Ziel:<br>- Geben Sie einen kurzen Überblick über Ihre Karriereziele, Fähigkeiten und Erfahrungen.</p><p>4. Berufserfahrung:<br>- Listen Sie Ihre Berufserfahrung in umgekehrter chronologischer Reihenfolge auf.<br>- Enthalten Sie den Jobtitel, den Firmennamen, den Standort und die Beschäftigungszeiträume für jede Position.</p><p>5. Ausbildung:<br>- Fügen Sie Ihren Ausbildungshintergrund sowie den Namen der Institution hinzu.</p><p>6. Fähigkeiten:<br>- Heben Sie Ihre wichtigsten Fähigkeiten und Kompetenzen hervor, die für den Job relevant sind.</p><p>7. Erfolge und Auszeichnungen:<br>- Showcase your achievements or awards you've received in your career to demonstrate impact.</p><p>8. Zusätzliche Abschnitte (optional):<br>- Fügen Sie zusätzliche Abschnitte wie Zertifizierungen, berufliche Mitgliedschaften, freiwillige Erfahrungen oder Sprachkenntnisse hinzu, wenn relevant.</p><p>Die obigen Schlüsselpunkte sind sehr wichtig, aber die Anpassung des Inhalts ist entscheidend.<br>Passen Sie Ihren Lebenslauf für jede Bewerbung an, um die relevantesten Fähigkeiten und Erfahrungen hervorzuheben.<br>Verwenden Sie Schlüsselwörter aus der Stellenbeschreibung, um Ihren Lebenslauf zu optimieren und eine Übereinstimmung mit der Rolle zu zeigen.</p><p>Korrekturlesen und Bearbeiten sind ebenfalls ein Muss.<br>Überprüfen Sie den Lebenslauf, um sicherzustellen, dass keine Tippfehler, Grammatikfehler oder Formatinkonsistenzen vorliegen.<br>Holen Sie sich Ratschläge von einem vertrauenswürdigen Freund, Mentor oder Fachmann, um Ihren Lebenslauf zu überprüfen und Feedback zu erhalten, bevor Sie ihn potenziellen Arbeitgebern vorlegen.</p>" },
        { "S1_Expanded_Spanish", "<p>Puntos Clave de un CV Bien Escrito:</p><p>1. Utiliza un Formato Claro y Conciso:<br>- Emplea un diseño limpio y profesional.<br>- Mantén tu CV en un máximo de una o dos páginas.</p><p>2. Información de Contacto:<br>- Incluye tu nombre, número de teléfono, dirección de correo electrónico y perfil de LinkedIn (si corresponde).</p><p>3. Resumen Profesional/Objetivo:<br>- Proporciona una breve descripción de tus metas profesionales, habilidades y experiencia.</p><p>4. Experiencia Laboral:<br>- Enumera tu experiencia laboral en orden cronológico inverso.<br>- Incluye el título del puesto, el nombre de la empresa, la ubicación y las fechas de empleo para cada posición.</p><p>5. Educación:<br>- Incluye tu formación académica y el nombre de la institución.</p><p>6. Habilidades:<br>- Destaca tus habilidades clave y competencias relevantes para el puesto.</p><p>7. Logros y Premios:<br>- Muestra tus logros o premios recibidos en tu carrera para demostrar impacto.</p><p>8. Secciones Adicionales (Opcional):<br>- Incluye secciones adicionales como certificaciones, membresías profesionales, experiencia como voluntario o habilidades lingüísticas si son relevantes.</p><p>Los puntos clave anteriores son muy importantes, pero personalizar tu contenido es esencial.<br>Adapta tu CV para cada solicitud de trabajo para resaltar las habilidades y experiencias más relevantes.<br>Utiliza palabras clave de la descripción del trabajo para optimizar tu CV y demostrar alineación con el rol.</p><p>La corrección y edición también son fundamentales.<br>Revisa el CV para confirmar que no haya errores tipográficos, errores gramaticales o inconsistencias de formato.<br>Busca consejo de un amigo de confianza, mentor o profesional para revisar tu CV y darte retroalimentación antes de enviarlo a posibles empleadores.</p>" },
        { "S2_Default_English", "<p>Below is a basic CV template that you can use as a starting point.<br>Remember to customize it with your own information, experiences, and skills.</p><p>1. Provide contact information:<br>[Your Name, Address, City, State, ZIP Code, Phone Number, Email Address, LinkedIn Profile]</p><p>2. Write a brief statement outlining your career goals or what you aim to achieve in your desired position.</p><p>3. Your Education:<br>[Degree], [University Name], [Graduation Date]</p><p>4. Describe your work experience:<br>[Job Title], [Company Name], [Location], [Dates of Employment]</p><p>5. List your Skills:<br>[Skill #1#2#3] &amp; [Certification #1#2#3]</p><p>6. Additional Information:<br>[Languages spoken, if applicable]<br>[Volunteer experience or community involvement, if applicable]</p>" },
        { "S2_Default_German", "<p>Nachfolgend finden Sie eine grundlegende Lebenslaufvorlage, die Sie als Ausgangspunkt verwenden können.<br>Denken Sie daran, es mit Ihren eigenen Informationen, Erfahrungen und Fähigkeiten anzupassen.</p><p>1. Geben Sie Ihre Kontaktdaten an:<br>[Ihr Name, Adresse, Stadt, Bundesland, Postleitzahl, Telefonnummer, E-Mail-Adresse, LinkedIn-Profil]</p><p>2. Schreiben Sie eine kurze Aussage, in der Ihre Berufsziele oder das, was Sie in der gewünschten Position erreichen möchten, skizziert werden.</p><p>3. Ihre Ausbildung:<br>[Abschluss], [Universitätsname], [Abschlussdatum]</p><p>4. Beschreiben Sie Ihre Berufserfahrung:<br>[Stellenbezeichnung], [Firmenname], [Ort], [Beschäftigungszeiträume]</p><p>5. Listen Sie Ihre Fähigkeiten auf:<br>[Fähigkeit #1#2#3] &amp; [Zertifizierung #1#2#3]</p><p>6. Zusätzliche Informationen:<br>[Gesprochene Sprachen, wenn zutreffend]<br>[Erfahrungen als Freiwilliger oder Engagement in der Gemeinde, wenn zutreffend]</p>" },
        { "S2_Default_Spanish", "<p>A continuación se muestra una plantilla básica de CV que puedes utilizar como punto de partida.<br>Recuerda personalizarla con tu propia información, experiencias y habilidades.</p><p>1. Proporcionar información de contacto:<br>[Nombre Completo, Dirección, Ciudad, Estado, Código Postal, Teléfono, Correo Electrónico], Perfil de LinkedIn]</p><p>2. Redacta un breve documento describiendo tus objetivos profesionales o lo que aspiras lograr en el puesto deseado.</p><p>3. Educación:<br>[Título], [Nombre de la Universidad], [Fecha de Graduación]</p><p>4. Describe tu experiencia laboral:<br>[Título del Trabajo], [Nombre de la Empresa], [Ubicación], [Fechas de Empleo]</p><p>5. Enumera tus habilidades:<br>[Habilidad #1#2#3] &amp; [Certificación #1#2#3]</p><p>6. Información adicional:<br>[Idiomas hablados, si corresponde]<br>[Experiencia como voluntario o participación comunitaria, si corresponde]</p>" },
        { "S2_Simplified_English", "<p>Below is a basic CV template that you can use as a starting point.<br>Remember to customize it with your own information, experiences, and skills.</p><p>1. Contact information.</p><p>2. Objective.</p><p>3. Your Education.</p><p>4. A description of your work experience.</p><p>5. A list of your Skills.</p><p>6. Additional Information.</p>" },
        { "S2_Simplified_German", "<p>Nachfolgend finden Sie eine grundlegende Lebenslaufvorlage, die Sie als Ausgangspunkt verwenden können.<br>Denken Sie daran, es mit Ihren eigenen Informationen, Erfahrungen und Fähigkeiten anzupassen.</p><p>1. Kontaktinformationen.</p><p>2. Zielsetzung.</p><p>3. Ihre Ausbildung.</p><p>4. Eine Beschreibung Ihrer Berufserfahrung.</p><p>5. Eine Liste Ihrer Fähigkeiten.</p><p>6. Zusätzliche Informationen.</p>" },
        { "S2_Simplified_Spanish", "<p>A continuación se muestra una plantilla básica de CV que puedes utilizar como punto de partida.<br>Recuerda personalizarla con tu propia información, experiencias y habilidades.</p><p>1. Información de Contacto.</p><p>2. Objetivo.</p><p>3. Educación.</p><p>4. Una descripción de tu experiencia laboral.</p><p>5. Una lista de tus Habilidades.</p><p>6. Información Adicional.</p>" },
        { "S2_Expanded_English", "<p>Below is an extended CV template that you can use as a starting point.<br>Remember to customize it with your own information, experiences, and skills.</p><p>[Contact Information]<br>[Your Name]<br>[Your Address]<br>[City, State, ZIP Code]<br>[Your Phone Number]<br>[Your Email Address]<br>[Your LinkedIn Profile (optional)]</p><p>Professional Summary:<br>[Insert a brief summary highlighting your career goals, skills, and experiences.]</p><p>Work experience:<br>- [Job Title]<br>- [Company Name], [Location]<br>- [Dates of Employment]</p><p>Education:</p><p>- [Degree] in [Field of Study]<br>- [University Name], [Location]<br>- [Graduation Date or Expected Graduation Date]</p><p>High School Diploma:<br>- [High School Name], [Location]<br>- [Graduation Date]</p><p>Skills:<br>- [Skill #1#2#3]</p><p>Certifications (if applicable):<br>- [Certification #1#2#3]</p><p>Professional Memberships (if applicable):<br>- [Membership #1#2#3]</p><p>Languages:<br>- [Language #1]: [Proficiency Level]</p><p>Additional Information (optional):<br>- [Volunteer Experience] & [Hobbies/Interests]</p><p>Feel free to adjust and customize this template to best suit your needs and the requirements of the job you're applying for.</p>" },
        { "S2_Expanded_German", "<p>Nachfolgend finden Sie eine erweiterte Lebenslaufvorlage, die Sie als Ausgangspunkt verwenden können.<br>Denken Sie daran, es mit Ihren eigenen Informationen, Erfahrungen und Fähigkeiten anzupassen.</p><p>[Kontaktinformationen]<br>[Ihr Name]<br>[Ihre Adresse]<br>[Stadt, Bundesland, Postleitzahl]<br>[Ihre Telefonnummer]<br>[Ihre E-Mail-Adresse]<br>[Ihr LinkedIn-Profil (optional)]</p><p>Berufliche Zusammenfassung:<br>[Fügen Sie eine kurze Zusammenfassung ein, die Ihre Karriereziele, Fähigkeiten und Erfahrungen hervorhebt.]</p><p>Berufserfahrung:<br>- [Berufsbezeichnung]<br>- [Firmenname], [Ort]<br>- [Beschäftigungszeiträume]</p><p>Ausbildung:</p><p>- [Abschluss] in [Studiengang]<br>- [Universitätsname], [Ort]<br>- [Abschlussdatum oder Voraussichtliches Abschlussdatum]</p><p>Abschlusszeugnis der Sekundarstufe:<br>- [Name der High School], [Ort]<br>- [Abschlussdatum]</p><p>Fähigkeiten:<br>- [Fähigkeit #1#2#3]</p><p>Zertifizierungen (falls zutreffend):<br>- [Zertifizierung #1#2#3]</p><p>Berufliche Mitgliedschaften (falls zutreffend):<br>- [Membership #1#2#3]</p><p>Sprachen:<br>- [Sprache #1]: [Sprachkenntnisse]</p><p>Zusätzliche Informationen (optional):<br>- [Ehrenamtliche Erfahrung] & [Hobbys/Interessen]</p><p>Zögern Sie nicht, diese Vorlage an Ihre Bedürfnisse und die Anforderungen der Stelle, auf die Sie sich bewerben, anzupassen.</p>" },
        { "S2_Expanded_Spanish", "<p>A continuación se muestra una plantilla extendida de CV que puedes utilizar como punto de partida.<br>Recuerda personalizarla con tu propia información, experiencias y habilidades.</p><p>[Información de Contacto]<br>[Nombre Completo]<br>[Dirección]<br>[Ciudad, Estado, Código Postal]<br>[Teléfono]<br>[Correo Electrónico]]<br>[Perfil de LinkedIn (opcional)]</p><p>Resumen Profesional:<br>[Inserta un breve resumen resaltando tus objetivos profesionales, habilidades y experiencias.]</p><p>Experiencia Laboral:<br>- [Título del Trabajo]<br>- [Nombre de la Empresa], [Ubicación]<br>- [Fechas de Empleo]</p><p>Educación:</p><p>- [Título] en [Campo de Estudio]<br>- [Nombre de la Universidad], [Ubicación]<br>- [Fecha de Graduación o Fecha de Graduación Esperada]</p><p>Diploma de Escuela Secundaria:<br>- [Nombre de la Escuela Secundaria], [Ubicación]<br>- [Fecha de Graduación]</p><p>Habilidades:<br>- [Habilidad #1#2#3]</p><p>Certificaciones (si corresponde):<br>- [Certificación #1#2#3]</p><p>Membresías Profesionales (si corresponde):<br>- [Membresía #1#2#3]</p><p>Idiomas:<br>- [Idioma #1]: [Nivel de Competencia]</p><p>Información Adicional (opcional):<br>- [Experiencia Voluntaria] y [Pasatiempos/Intereses]</p><p>Siéntete libre de ajustar y personalizar esta plantilla para que se adapte mejor a tus necesidades y a los requisitos del trabajo para el que estás aplicando.</p>" }
    };

    public const string InfoMessage = "For real prompt processing, please connect the component to a preferred AI service. You can use one of the items from the \"Prompt Suggestions\" section in the Prompt View to get a sample result.";
    public const string InfoMessageHtml = "<p>For real prompt processing, please connect the component to a preferred AI service. You can use one of the items from the \"Prompt Suggestions\" section in the Prompt View to get a sample result.</p>";

    private SuggestionId suggestionId;
    private Format format;
    private Language language;

    public Task<AiItem> GetLLMResponseAsync(string instruction, string inputText)
    {
        return Task.Run<AiItem>(() =>
        {
            Task.Delay(2000);

            string key = this.TryGetKey(instruction);
            return GenerateAiItem(key, inputText);
        });
    }

    public Task<AiItem> RetryGettingLLMResponseAsync(AiItem oldAiItem)
    {
        return Task.Run<AiItem>(() =>
        {
            Task.Delay(2000);

            this.suggestionId = oldAiItem.suggestionId;
            this.format = oldAiItem.format;
            this.language = oldAiItem.language;
            string key = this.GetKey();
            return GenerateAiItem(key, oldAiItem.inputText);
        });
    }

    private string GetKey()
    {
        string key = $"{this.suggestionId}_{this.format}_{this.language}";
        return key;
    }

    private string TryGetKey(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }

        if (text == "Generate key points of a well-written CV")
        {
            this.suggestionId = SuggestionId.S1;
            this.format = Format.Default;
            this.language = Language.English;
        }
        else if (text == "Generate a CV template")
        {
            this.suggestionId = SuggestionId.S2;
            this.format = Format.Default;
            this.language = Language.English;
        }
        else if (text.StartsWith("Simplify this: "))
        {
            this.format = Format.Simplified;
        }
        else if (text.StartsWith("Expand this: "))
        {
            this.format = Format.Expanded;
        }
        else if (text.StartsWith("Translate to German: "))
        {
            this.language = Language.German;
        }
        else if (text.StartsWith("Translate to Spanish: "))
        {
            this.language = Language.Spanish;
        }
        else
        {
            this.suggestionId = SuggestionId.Undefined;
            return null;
        }

        if (this.suggestionId == SuggestionId.Undefined)
        {
            return null;
        }

        return this.GetKey();
    }

    private AiItem GenerateAiItem(string key, string inputText)
    {
        if (key != null && llm.TryGetValue(key, out string response))
        {
            string html = llmHtml[key];
            AiItem aiItem = new AiItem(inputText, response, html, this.suggestionId, this.format, this.language);
            return aiItem;
        }
        else
        {
            AiItem aiItem = new AiItem(inputText, InfoMessage, InfoMessageHtml);
            return aiItem;
        }
    }
}
