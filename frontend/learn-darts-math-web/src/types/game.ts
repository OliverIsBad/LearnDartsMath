export type GameState = {
  trainingSessionId: number
  startScore: number
  currentScore: number
  isFinished: boolean
  mode: string
}

export type StartGameRequest = {
  startScore: number
  mode: string
}

export type SubmitTurnRequest = {
  trainingSessionId: number
  enteredScoredPoints: number
  enteredRemainingScore: number
}

export type TurnResult = {
  previousScore: number
  enteredScoredPoints: number
  enteredRemainingScore: number
  correctRemainingScore: number
  isScoreValid: boolean
  isRemainingCorrect: boolean
  isCorrect: boolean
  newCurrentScore: number
}