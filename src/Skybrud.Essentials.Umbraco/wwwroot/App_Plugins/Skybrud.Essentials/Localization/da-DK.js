function meh(count, singular, plural) {
	count = parseInt(count);
	if (count === 1) return `${count} ${singular}`;
	if (count > 1 || count === 0) return `${count} ${plural}`;
	return plural;
}

export default {
	skybrud: {
		ago: "siden",
		in: "om",
		day: "dag",
		days: (c) => meh(c, "dag", "dage"),
		minute: "minut",
		minutes: (c) => meh(c, "minut", "minutter"),
		hour: "time",
		hours: (c) => meh(c, "time", "timer"),
		second: "sekund",
		seconds: (c) => meh(c, "sekund", "sekunder"),
		now: "nu",
		and: "og",
		na: "N/A"
	}
}