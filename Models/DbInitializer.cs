using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A10.Models
{
    public static class DbInitializer
    {
        public static void Initialize(MembershipContext context)
        {
            context.Database.EnsureCreated();
            // if already records then skip
            if (context.Members.Any())
            { return; }

            context.Members.Add(new Member()
            {
                memberId = 101,
                firstName = "Joe",
                lastName = "Doe",
                streetAddress = "7070 Anywhere Place",
                city = "River Forest",
                state = "IL",
                zipCode = 60305,
                emailAddress = "joedoe@somewhere.com",
                phoneHome = "708-366-3696",
                phoneCell = "708-998-0873",
                membershipTypeId = 1,
                employerCompanyName = "XYZ Firm",
                employerPhoneNumber = "630-445-9809",
                membershipStatusId = 1,
                emergencyContactName = "Jane Doe",
                emergencyContactPhone = "708-366-3696",
                emergencyContactRelationship = "Spouse",
                primaryLocationId = 3
            });

            context.Members.Add(new Member()
            {
                memberId = 102,
                firstName = "Herman",
                lastName = "Munster",
                streetAddress = "1313 Mockingbird Lane",
                city = "Mockingbird Heights",
                state = "IL",
                zipCode = 90000,
                emailAddress = "herman@frights.com",
                phoneHome = "310-100-1009",
                phoneCell = "310-100-1009",
                membershipTypeId = 2,
                employerCompanyName = "Gateman Goodbury and Graves",
                employerPhoneNumber = "310-101-1109",
                membershipStatusId = 1,
                emergencyContactName = "Lily",
                emergencyContactPhone = "310-100-1009",
                emergencyContactRelationship = "Spouse",
                primaryLocationId = 1
            });
            context.Locations.Add(new Location()
            {
                locationId = 1,
                locationShortName = "AZIPPY Schaumburg",
                locationStreetAddress = "1704 E Higgins",
                city = "Schaumburg",
                state = "IL",
                zipCode = 603173,
                locationphoneNumber = "847-706-5590"
            });

            context.Locations.Add(new Location()
            {
                locationId = 3,
                locationShortName = "AZIPPY Oak Park",
                locationStreetAddress = "403 N Harlem",
                city = "Oak Park",
                state = "IL",
                zipCode = 60301,
                locationphoneNumber = "708-445-5460"
            });

            context.MembershipStatuses.Add(new MembershipStatus()
            {
                membershipStatusId = 1,
                membershipStatusDescription = "Good standing"
            });

            context.MembershipStatuses.Add(new MembershipStatus()
            {
                membershipStatusId = 2,
                membershipStatusDescription = "Banned"
            });
            context.MembershipStatuses.Add(new MembershipStatus()
            {
                membershipStatusId = 3,
                membershipStatusDescription = "Suspended"
            });
            context.MembershipStatuses.Add(new MembershipStatus()
            {
                membershipStatusId = 4,
                membershipStatusDescription = "Quit"
            });

            context.MembershipTypes.Add(new MembershipType()
            {
                membershipTypeId = 1,
                membershipTypeDescription = "Single",
                membershipMonthlyRate = 75.0
            });

            context.MembershipTypes.Add(new MembershipType()
            {
                membershipTypeId = 2,
                membershipTypeDescription = "Family",
                membershipMonthlyRate = 160.0
            });
            context.MembershipTypes.Add(new MembershipType()
            {
                membershipTypeId = 3,
                membershipTypeDescription = "Social",
                membershipMonthlyRate = 60.0
            });
            context.FitnessClasses.Add(new FitnessClass()
            {
                fitnessclassId = 101,
                fitnessclassTitle = "Interval Training",
                fitnessclassDuration = 60,
                fitnessclassCaloriesBurnedApprox = 400,
                fitnessclassFee = 10.0,
                fitnessclassMaxEnrollees = 15,
                fitnessclassDescription = "Interval training is a type of training that involves a series of low- to high-intensity "
                                               + "workouts interspersed with rest or relief periods. The " +
                                               "high-intensity periods are typically at or close to " + "anaerobic exercise, or an effort that feels hard or very" +
                                               " hard, while the recovery periods involve activity of lower " +
                                               "heart muscle, providing a cardio vascular workout, improving aerobic capacity. As an example, an interval workout might " +
                                               "consist of alternating between 30 seconds of running at a sprint pace and 60 seconds of walking. Interval training can refer to the " +
                                               "organization of any cardiovascular workout(e.g., cycling, running, rowing). It is prominent in training routines for many sports, but is " +
                                               "particularly employed by runners."
            });
            context.PersonalTrainers.Add(new PersonalTrainer()
            {
                trainerFirstName = "Boris",
                trainerLastName = "Bulksquat",
                trainerGender = "M",
                trainerId = 1001,
                trainerSpecialities = "core training, body building, strength training",
                trainerPrimaryLocationId = 1
            });
            context.ClassSessions.Add(new ClassSession()
            {
                classSessionId = 1,
                fitnessClassId = 101,
                ClassSessionStartTime = new DateTime(2019, 10, 30, 17, 30, 0),
                locationId = 1
            });
            context.ClassEnrollees.Add(new ClassEnrollee()
            { 
                classSessionId = 1,
                memberId = 102
            });
            context.SaveChanges();
        }

    }
}
