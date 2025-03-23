function meh(count, singular, plural) {
	count = parseInt(count);
	if (count === 1) return `${count} ${singular}`;
	if (count > 1 || count === 0) return `${count} ${plural}`;
	return plural;
}

export default {
	skybrud: {
		ago: "ago",
		in: "in",
		day: "day",
		days: (c) => meh(c, "day", "days"),
		minute: "minute",
		minutes: (c) => meh(c, "minute", "minutes"),
		hour: "hour",
		hours: (c) => meh(c, "hour", "hours"),
		second: "second",
		seconds: (c) => meh(c, "second", "seconds"),
		now: "now",
		and: "and",
		na: "N/A",
		items: (c) => meh(c, "item", "items"),
		properties: (c) => meh(c, "property", "properties")
	}
}