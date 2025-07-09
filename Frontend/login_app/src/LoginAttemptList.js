import React from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({login}) => <li>Name: {login}</li>;

const LoginAttemptList = (props) => {
	const [filter, setFilter] = React.useState("");

	const filteredAttempts = props.attempts ? props.attempts.filter(attempt =>
		attempt.login.startsWith(filter)
	) : [];

	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input type="input" placeholder="Filter..." value={filter} onChange={e => setFilter(e.target.value)} />
			<ul className="Attempt-List">
				{
					filteredAttempts && filteredAttempts.map((loginAttempt, idx) => (
						<LoginAttempt key={idx} login={loginAttempt.login} />
					))
				}
			</ul>
		</div>
	)
};

export default LoginAttemptList;
